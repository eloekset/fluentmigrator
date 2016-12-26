using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMigrator.Example.Migrations
{
    [Migration(20091227124300)]
    public class _3_DropIndex : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Delete.Index("IDX_Notes_CreatedAt").OnTable("Notes").OnColumn("CreatedAt")
                .ApplyOnline(Model.OnlineMode.On);
        }
    }
}
