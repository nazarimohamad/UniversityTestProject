using System;
using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(202221271036)]
    public class _202212271036_create_semester_table : Migration
    {
        public _202212271036_create_semester_table()
        {
        }

        public override void Up()
        {
            Create.Table("Semesters")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Number").AsInt32().NotNullable()
                  .WithColumn("Year").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Semesters");
        }
    }
}

