using System;

namespace SilverNBTLibrary.PE.LevelDB
{
    public class Cache
    {
        private IntPtr _handle;
        internal IntPtr Handle { get { return _handle; } }

        private Cache(IntPtr handle)
        {
            _handle = handle;
        }

        public static Cache Create(int capacity)
        {
            return new Cache(LevelDBImpl.leveldb_cache_create_lru((UIntPtr)capacity));
        }

        ~Cache()
        {
            LevelDBImpl.leveldb_cache_destroy(_handle);
        }
    }
}
