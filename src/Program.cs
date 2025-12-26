using System;
using System.Reflection;
using Microsoft.Data.Sqlite;
using SQLitePCL;

raw.SetProvider(new SQLite3Provider_e_sqlite3());

using var dataSource = SqliteFactory.Instance.CreateDataSource("Data Source=:memory:");
using var command = dataSource.CreateCommand("select sqlite_version()");
var version = command.ExecuteScalar();

var assembly = typeof(SqliteConnection).Assembly;
var info = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? assembly.GetName().Version?.ToString();
Console.WriteLine($"✔️ {assembly.GetName().Name} {info} is working with Native AOT and {raw.GetNativeLibraryName()} version {version}");
