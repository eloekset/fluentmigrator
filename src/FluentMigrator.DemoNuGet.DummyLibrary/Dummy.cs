using System;

namespace FluentMigrator.DemoNuGet.DummyLibrary
{
    public class Dummy
    {
        public static Version Version
        {
            get { return typeof(Dummy).Assembly.GetName().Version; }
        }
        public static string Description
        {
            get
            {
                return $"Version {Version}";
            }
        }
    }
}
