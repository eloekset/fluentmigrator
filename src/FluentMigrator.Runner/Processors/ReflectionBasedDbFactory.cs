namespace FluentMigrator.Runner.Processors
{
    using System;
    using System.Data.Common;
    using System.Linq;

    public class ReflectionBasedDbFactory : DbFactoryBase
    {
        private readonly string assemblyName;
        private readonly string dbProviderFactoryTypeName;

        public ReflectionBasedDbFactory(string assemblyName, string dbProviderFactoryTypeName)
        {
            this.assemblyName = assemblyName;
            this.dbProviderFactoryTypeName = dbProviderFactoryTypeName;
        }

        protected override DbProviderFactory CreateFactory()
        {
#if NETSTANDARD2_0
            var dbProviderAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith(assemblyName)).FirstOrDefault();

            if (dbProviderAssembly == null)
            {
                throw new Exception($"No DB provider assembly named {assemblyName} is loaded.");
            }

            var factoryType = dbProviderAssembly.GetType(dbProviderFactoryTypeName);

            if (factoryType == null)
            {
                throw new Exception($"No DB provider factory named {dbProviderFactoryTypeName} found in assembly {assemblyName}.");
            }

            if (factoryType.GetConstructors(System.Reflection.BindingFlags.Public).Any())
            {
                return (DbProviderFactory)Activator.CreateInstance(factoryType);
            }

            var singletonField = factoryType.GetField("Instance", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            if (singletonField != null)
            {
                return (DbProviderFactory)singletonField.GetValue(factoryType);
            }

            throw new Exception($"Not able to create an instance of {dbProviderFactoryTypeName}.");
#else
            return (DbProviderFactory)AppDomain.CurrentDomain.CreateInstanceAndUnwrap(assemblyName, dbProviderFactoryTypeName);
#endif
        }
    }
}