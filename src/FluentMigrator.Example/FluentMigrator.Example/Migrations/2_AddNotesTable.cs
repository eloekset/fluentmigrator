#region License
// 
// Copyright (c) 2007-2009, Sean Chambers <schambers80@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;

namespace FluentMigrator.Example.Migrations
{
	[Migration(20090906205440)]
	public class AddNotesTable : Migration
	{
		public override void Up()
		{
			Create.Table("Notes")
				.WithColumn("NotesId").AsGuid()
				.WithColumn("Body").AsString(4000).NotNullable()
				.WithTimeStamps()
				.WithColumn("User_id").AsInt32();

            Create.Index("IDX_Notes_CreatedAt").OnTable("Notes")
                .WithOptions().ApplyOnline(Model.OnlineMode.On)
                .WithOptions().Clustered()
                .OnColumn("CreatedAt");

            Create.PrimaryKey("PK_Notes").OnTable("Notes")
                .Column("NotesId").ApplyOnline(Model.OnlineMode.On);
		}

		public override void Down()
		{
			Delete.Table("Notes");
            Delete.Index("IDX_Notes_CreatedAt").WithOptions().ApplyOnline(Model.OnlineMode.On);
		}
	}
}
