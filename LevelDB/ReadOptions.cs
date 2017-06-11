using System;
namespace SilverNBTLibrary.PE.LevelDB
{
    public class ReadOptions
    {
        private IntPtr _handle;
        public IntPtr Handle { get { return _handle; } }
        public ReadOptions()
        {
            _handle = LevelDBImpl.leveldb_readoptions_create();
        }

        ~ReadOptions()
        {
            LevelDBImpl.leveldb_readoptions_destroy(_handle);
        }
    }
}
