using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System;
using System.Reflection;

namespace Fluent.NetStandardTest
{
    class Program
    {
        private static readonly ConsoleAnnouncer consoleAnnouncer = new ConsoleAnnouncer();
        private static RunnerContext RunnerContext { get; set; }

        static void Main(string[] args)
        {
            consoleAnnouncer.Header();
            consoleAnnouncer.Emphasize("Attach debugger now and press any key to execute migrations...");
            Console.ReadKey();
            
            ExecuteMigrations(consoleAnnouncer);


            Console.ReadKey();
        }

        private static void ExecuteMigrations(IAnnouncer announcer)
        {
            Microsoft.Data.Sqlite.SqliteFactory factory = Microsoft.Data.Sqlite.SqliteFactory.Instance;
            RunnerContext = new RunnerContext(announcer)
            {
                Database = "SQLite",
                Connection = @"Data Source=.\dbfile.db",
                Targets = new string[] { Assembly.GetExecutingAssembly().FullName },
                Task = "migrate:up",
            };

            new TaskExecutor(RunnerContext).Execute();
        }
    }
}
