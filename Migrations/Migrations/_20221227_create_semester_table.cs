using System;
using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(20222127)]
    public class _20221227_create_semester_table : Migration
    {
        public _20221227_create_semester_table()
        {
        }

        public override void Up()
        {
            Create.Table("Semester")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Number").AsInt32().NotNullable()
                  .WithColumn("Year").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Semester");
        }
    }
}

