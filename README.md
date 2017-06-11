# SNL.PE

実際はほぼLevelDBのラッパー状態
DLLをぽいっとするのがミソ。
```
    using SilverNBTLibrary.PE.LevelDB;
    DB level = new SDB(@"./world/db", createIfMissing: false);
    foreach(var pair in level)
    {
        Console.WriteLine("{0}", BitConverter.ToString(pair.Key));
    }
```
ネイティブのx64版とx86版かどっちかでコンパイルしたMCPEのDLLを「leveldb.dll」としてdllフォルダに入れる。
うまく出来なかったら聞いてくれ。
