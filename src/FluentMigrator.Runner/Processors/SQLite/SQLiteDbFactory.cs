namespace FluentMigrator.Runner.Processors.SQLite
{
    public class SQLiteDbFactory : ReflectionBasedDbFactory
    {
#if NETSTANDARD2_0
        private const string AssemblyName = "Microsoft.Data.Sqlite";
        private const string DbProviderFactoryTypeName = "Microsoft.Data.Sqlite.SqliteFactory";
#else
        private const string AssemblyName = "System.Data.SQLite";
        private const string DbProviderFactoryTypeName = "System.Data.SQLite.SQLiteFactory";
#endif
        public SQLiteDbFactory()
            : base(AssemblyName, DbProviderFactoryTypeName)
        {
        }
    }
}