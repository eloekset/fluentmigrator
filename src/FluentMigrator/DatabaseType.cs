
namespace FluentMigrator
{
    public enum DatabaseType
    {
        SqlServer2000 = 1,
        SqlServer2005 = 2,
        SqlServer2008 = 4,
        SqlServer2012 = 8,
        SqlServer2014 = 16,
        SqlServer = 1 + 2 + 3 + 4 + 8 + 16,
        SqlServerCe = 32,
        SQLite = 64,
        Postgres = 128,
        Oracle = 256,
        MySql = 512,
        Jet = 1024,
        Hana = 2048,
        Firebird = 4096,
        Db2 = 8192
    }
}