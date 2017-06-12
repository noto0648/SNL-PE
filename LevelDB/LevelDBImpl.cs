using System;
using System.Text;
using System.Runtime.InteropServices;

namespace SilverNBTLibrary.PE.LevelDB
{
    internal static class LevelDBImpl
    {
        /* DB operations */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_open(IntPtr options, string name, out IntPtr error);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_close(IntPtr db);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_put(IntPtr db, IntPtr writeOptions, string key, UIntPtr keyLength, string value, UIntPtr valueLength, out IntPtr error);

        /* bytearray */
        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_put(IntPtr db, IntPtr writeOptions, byte[] key, UIntPtr keyLength, byte[] value, UIntPtr valueLength, out IntPtr error);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_delete(IntPtr db, IntPtr writeOptions, string key, UIntPtr keylen, out IntPtr error);

        /* bytearray */
        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_delete(IntPtr db, IntPtr writeOptions, byte[] key, UIntPtr keylen, out IntPtr error);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_write(IntPtr db, IntPtr writeOptions, IntPtr writeBatch, out IntPtr error);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_get(IntPtr db, IntPtr readOptions, string key, UIntPtr keyLength, out UIntPtr valueLength, out IntPtr error);

        /* bytearray */
        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_get(IntPtr db, IntPtr readOptions, byte[] key, UIntPtr keyLength, out UIntPtr valueLength, out IntPtr error);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_iterator(IntPtr db, IntPtr readOptions);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_snapshot(IntPtr db);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_release_snapshot(IntPtr db, IntPtr snapshot);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_property_value(IntPtr db, string propname);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_compact_range(IntPtr db, string startKey, UIntPtr startKeyLen, string limitKey, UIntPtr limitKeyLen);

        /* Management operations */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_destroy_db(IntPtr options, string path, out IntPtr error);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_repair_db(IntPtr options, string path, out IntPtr error);

        /* Iterator */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek_to_first(IntPtr iter);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek_to_last(IntPtr iter);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek(IntPtr iter, string key, UIntPtr keyLength);

        /* bytearray */
        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_seek(IntPtr iter, byte key, UIntPtr keyLength);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte leveldb_iter_valid(IntPtr iter);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_prev(IntPtr iter);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_next(IntPtr iter);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_iter_key(IntPtr iter, out UIntPtr keyLength);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_iter_value(IntPtr iter, out UIntPtr valueLength);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_iter_destroy(IntPtr iter);

        /* Write batch */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_writebatch_create();

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_destroy(IntPtr writeBatch);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_clear(IntPtr writeBatch);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writebatch_put(IntPtr writeBatch, string key, UIntPtr keyLength, string value, UIntPtr valueLength);

        /* Options */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_options_create();

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_destroy(IntPtr options);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_comparator(IntPtr options, IntPtr comparator);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_create_if_missing(IntPtr options, bool value);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_error_if_exists(IntPtr options, bool value);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_paranoid_checks(IntPtr options, bool value);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_max_open_files(IntPtr options, int value);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_compression(IntPtr options, int value);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_cache(IntPtr options, IntPtr cache);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_block_size(IntPtr options, UIntPtr size);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_write_buffer_size(IntPtr options, UIntPtr size);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_options_set_block_restart_interval(IntPtr options, int interval);

        /* Read options */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_readoptions_create();

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_destroy(IntPtr readOptions);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_verify_checksums(IntPtr readOptions, bool value);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_fill_cache(IntPtr readOptions, bool value);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_readoptions_set_snapshot(IntPtr readOptions, IntPtr snapshot);

        /* Write options */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_writeoptions_create();

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writeoptions_destroy(IntPtr writeOptions);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_writeoptions_set_sync(IntPtr writeOptions, bool value);

        /* Cache */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_cache_create_lru(UIntPtr capacity);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_cache_destroy(IntPtr cache);

        /* Env */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr leveldb_create_default_env();

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_env_destroy(IntPtr cache);

        /* Utility */

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void leveldb_free(IntPtr ptr);

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int leveldb_major_version();

        [DllImport("leveldb.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int leveldb_minor_version();

        public static void PutString(IntPtr db, IntPtr writeOptions, string key, string value)
        {
            IntPtr error;
            UIntPtr keyLength = UTF8Length(key);
            UIntPtr valueLength = UTF8Length(value);
            leveldb_put(db, writeOptions, key, keyLength, value, valueLength, out error);
            ThrowError(error);
        }

        public static void Put(IntPtr db, IntPtr writeOptions, byte[] key, byte[] value)
        {
            IntPtr error;
            leveldb_put(db, writeOptions, key, (UIntPtr)key.Length, value, (UIntPtr)value.Length, out error);
            ThrowError(error);
        }

        public static string GetAsString(IntPtr db, IntPtr readOptions, string key)
        {
            UIntPtr valueLength;
            IntPtr error;
            UIntPtr keyLength = UTF8Length(key);
            var valuePtr = leveldb_get(db, readOptions, key, keyLength, out valueLength, out error);
            if (valuePtr == IntPtr.Zero || valueLength == UIntPtr.Zero)
                return null;
            ThrowError(error);
            var value = Marshal.PtrToStringAnsi(valuePtr, (int)valueLength);
            leveldb_free(valuePtr);
            return value;
        }

        public static byte[] Get(IntPtr db, IntPtr readOptions, byte[] key)
        {
            UIntPtr valueLength;
            IntPtr error;
            var valuePtr = leveldb_get(db, readOptions, key, (UIntPtr)key.Length, out valueLength, out error);
            if (valuePtr == IntPtr.Zero || valueLength == UIntPtr.Zero)
                return null;
            ThrowError(error);
            byte[] result = new byte[(int)valueLength];
            Marshal.Copy(valuePtr, result, 0, (int)valueLength);
            leveldb_free(valuePtr);
            return result;
        }

        public static void Delete(IntPtr db, IntPtr writeOptions, byte[] key)
        {
            IntPtr error;
            leveldb_delete(db, writeOptions, key, (UIntPtr)key.Length, out error);
            ThrowError(error);
        }

        public static void DeleteString(IntPtr db, IntPtr writeOptions, string key)
        {
            IntPtr error;
            UIntPtr keyLength = UTF8Length(key);
            leveldb_delete(db, writeOptions, key, keyLength, out error);
            ThrowError(error);
        }

        public static byte[] IteratorKey(IntPtr iter)
        {
            UIntPtr keyLength;
            var keyPtr = leveldb_iter_key(iter, out keyLength);
            if (keyPtr == IntPtr.Zero || keyLength == UIntPtr.Zero)
                return null;
            byte[] key = new byte[(int)keyLength];
            Marshal.Copy(keyPtr, key, 0, (int)keyLength);
            return key;
        }

        public static string IteratorKeyAsString(IntPtr iter)
        {
            UIntPtr keyLength;
            var keyPtr = leveldb_iter_key(iter, out keyLength);
            if (keyPtr == IntPtr.Zero || keyLength == UIntPtr.Zero)
                return null;
            var key = Marshal.PtrToStringAnsi(keyPtr, (int)keyLength);
            return key;
        }

        public static byte[] IteratorValue(IntPtr iter)
        {
            UIntPtr valueLength;
            var valuePtr = leveldb_iter_value(iter, out valueLength);
            if (valuePtr == IntPtr.Zero || valueLength == UIntPtr.Zero)
                return null;
            byte[] value = new byte[(int)valueLength];
            Marshal.Copy(valuePtr, value, 0, (int)valueLength);
            return value;
        }

        public static string IteratorValueAsString(IntPtr iter)
        {
            UIntPtr valueLength;
            var valuePtr = leveldb_iter_value(iter, out valueLength);
            if (valuePtr == IntPtr.Zero || valueLength == UIntPtr.Zero)
                return null;
            var value = Marshal.PtrToStringAnsi(valuePtr, (int)valueLength);
            return value;
        }

        public static void ThrowError(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return;
            var str = Marshal.PtrToStringAnsi(ptr);
            leveldb_free(ptr);
            throw new ArgumentException(str);
        }

        public static UIntPtr UTF8Length(this string value)
        {
            if (value == null || value.Length == 0)
            {
                return UIntPtr.Zero;
            }
            return new UIntPtr((uint)Encoding.UTF8.GetByteCount(value));
        }
    }
}
