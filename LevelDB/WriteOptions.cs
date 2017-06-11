using System;
namespace SilverNBTLibrary.PE.LevelDB
{
    public class WriteOptions
    {
        private IntPtr _handle;
        public IntPtr Handle { get { return _handle; } }
        public WriteOptions()
        {
            _handle = LevelDBImpl.leveldb_writeoptions_create();
        }

        ~WriteOptions()
        {
            LevelDBImpl.leveldb_writeoptions_destroy(_handle);
        }
    }
}
