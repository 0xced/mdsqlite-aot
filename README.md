This project demonstrates how to package [Microsoft.Data.Sqlite](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/) using [Native AOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/) on .NET 10

See https://github.com/0xced/mdsqlite-costura for packaging Microsoft.Data.Sqlite on .NET Framework using Costura.

## Motivation

After reading [Multiplatform AOT with SQLite: How to get it working!](https://www.mostlylucid.net/blog/en/multiplatform-aot-sqlite) by [Scott Galloway](https://hachyderm.io/@scottgal) I wanted to go one step further and getting rid of the SQLite native dynamic library altogether. It turns out it's possible to achieve by applying instructions found on [Native code interop with Native AOT - linking](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/interop#linking).

> [!NOTE]
> This has only been tested on macOS. It should work the same on Linux but will require a few adaptations to properly work on Windows.

## Instructions

1. Publish the solution

```sh
git clone https://github.com/0xced/mdsqlite-aot
cd mdsqlite-aot
dotnet publish
```

This will download and build SQLite 3.51.1 (see the `BuildSqlite` target) and build a single `mdsqlite` executable **statically linked** to the SQLite native library.

2. Run the executable

```sh
./src/bin/Release/net10.0/*/publish/mdsqlite
```

This will print

```
✔️ Microsoft.Data.Sqlite 10.0.1 is working with Native AOT and e_sqlite3 version 3.51.1
```

