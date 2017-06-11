using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilverNBTLibrary.PE.LevelDB
{
    public class DB : IDisposable, IEnumerable<KeyValuePair<byte[], byte[]>>
    {
        private IntPtr _optionsHandle;
        private IntPtr _dbHandle;

        public DB(string name)
        {
            OpenImpl(name);
        }

        public DB(string name, bool createIfMissing = false, bool errorIfExists = false, bool paranoidChecks = false, int writeBufferSize = 0, int maxOpenFile = 0, Cache blockCache = null, int blockSize = 0, int blockRestartInterval = 0, CompressionType compressionType = CompressionType.NoCompression)
        {
            SetOptions(createIfMissing, errorIfExists, paranoidChecks, writeBufferSize, maxOpenFile, blockCache, blockSize, blockRestartInterval, compressionType);
            OpenImpl(name);
        }

        private void OpenImpl(string name)
        {
            if (_optionsHandle == IntPtr.Zero)
            {
                SetOptions();
            }
            IntPtr err;
            _dbHandle = LevelDBImpl.leveldb_open(_optionsHandle, name, out err);
            LevelDBImpl.ThrowError(err);
        }

        private void SetOptions(bool createIfMissing = false, bool errorIfExists = false, bool paranoidChecks = false, int writeBufferSize = 0, int maxOpenFile = 0, Cache blockCache = null, int blockSize = 0, int blockRestartInterval = 0, CompressionType compressionType = CompressionType.NoCompression)
        {
            IntPtr handle = LevelDBImpl.leveldb_options_create();
            if (createIfMissing)
                LevelDBImpl.leveldb_options_set_create_if_missing(handle, true);

            if (errorIfExists)
                LevelDBImpl.leveldb_options_set_error_if_exists(handle, true);

            if (paranoidChecks)
                LevelDBImpl.leveldb_options_set_paranoid_checks(handle, true);

            if (writeBufferSize > 0)
                LevelDBImpl.leveldb_options_set_write_buffer_size(handle, (UIntPtr)writeBufferSize);

            if (maxOpenFile > 0)
                LevelDBImpl.leveldb_options_set_max_open_files(handle, maxOpenFile);

            if (blockCache != null)
                LevelDBImpl.leveldb_options_set_cache(handle, blockCache.Handle);

            if (blockSize > 0)
                LevelDBImpl.leveldb_options_set_block_size(handle, (UIntPtr)blockSize);

            if (blockRestartInterval > 0)
                LevelDBImpl.leveldb_options_set_block_restart_interval(handle, blockRestartInterval);

            LevelDBImpl.leveldb_options_set_compression(handle, (int)compressionType);

            _optionsHandle = handle;
        }

        public byte[] Get(byte[] key, ReadOptions options)
        {
            return LevelDBImpl.Get(_dbHandle, options.Handle, key);
        }

        public void Put(byte[] key, byte[] value, WriteOptions options)
        {
            LevelDBImpl.Put(_dbHandle,options.Handle, key, value);
        }

        public void Delete(byte[] key, WriteOptions options)
        {
            LevelDBImpl.Delete(_dbHandle, options.Handle, key);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {

            }

            if (_optionsHandle != IntPtr.Zero)
                LevelDBImpl.leveldb_options_destroy(_optionsHandle);

            if (_dbHandle != IntPtr.Zero)
                LevelDBImpl.leveldb_close(_dbHandle);

        }

        public IEnumerator<KeyValuePair<byte[], byte[]>> GetEnumerator()
        {
            return new Iterator(this, null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        ~DB()
        {
            Dispose(false);
        }


        public class Iterator : IDisposable, IEnumerator<KeyValuePair<byte[], byte[]>>
        {
            private IntPtr _handle;

            private DB _db;

            private bool IsFirstMove { get; set; }

            public bool IsValid
            {
                get
                {
                    return LevelDBImpl.leveldb_iter_valid(_handle)!=0;
                }
            }

            public byte[] Key
            {
                get
                {
                    return LevelDBImpl.IteratorKey(_handle);
                }
            }

            public byte[] Value
            {
                get
                {
                    return LevelDBImpl.IteratorValue(_handle);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public KeyValuePair<byte[], byte[]> Current
            {
                get
                {
                    return new KeyValuePair<byte[], byte[]>(Key, Value);
                }
            }

            internal Iterator(DB db, ReadOptions opt)
            {
                _db = db;
                if (opt == null)
                {
                    opt = new ReadOptions();
                }
                _handle = LevelDBImpl.leveldb_create_iterator(db._dbHandle, opt.Handle);
                IsFirstMove = true;
            }

            ~Iterator()
            {
                if (_db._dbHandle != IntPtr.Zero)
                {
                    LevelDBImpl.leveldb_iter_destroy(_handle);
                }
            }

            public void SeekToFirst()
            {
                LevelDBImpl.leveldb_iter_seek_to_first(_handle);
            }

            public void SeekToLast()
            {
                LevelDBImpl.leveldb_iter_seek_to_last(_handle);
            }

            public void Seek(string key)
            {
                LevelDBImpl.leveldb_iter_seek(_handle, key, key.UTF8Length());
            }

            public void Previous()
            {
                LevelDBImpl.leveldb_iter_prev(_handle);
            }

            public void Next()
            {
                LevelDBImpl.leveldb_iter_next(_handle);
            }

            public void Reset()
            {
                IsFirstMove = true;
                SeekToFirst();
            }

            public bool MoveNext()
            {
                if (IsFirstMove)
                {
                    SeekToFirst();
                    IsFirstMove = false;
                    return IsValid;
                }
                Next();
                return IsValid;
            }


            public void Dispose() { }
        }

    }
}
