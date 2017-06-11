using System;
using System.ComponentModel;

namespace SilverNBTLibrary.PE.LevelDB
{
    public enum CompressionType
    {
        NoCompression = 0,

        [EditorBrowsable(EditorBrowsableState.Never)]
        Snappy = 1,

        Zlib = 2
    }
}
