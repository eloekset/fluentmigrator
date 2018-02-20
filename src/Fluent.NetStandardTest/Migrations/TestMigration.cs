using FluentMigrator;
using System;

namespace Fluent.NetStandardTest.Migrations
{
    [Migration(1)]
    public class TestMigration : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Table("TestTable").Exists())
            {
                Create.Table("TestTable")
                    .WithColumn("Id").AsGuid()
                    .WithColumn("Name").AsString(200);
            }
        }
    }
}
