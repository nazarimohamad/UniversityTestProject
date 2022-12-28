using System;
using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(202212281148)]
    public class _202212281148_create_student_table : Migration
    {
        public override void Up()
        {
            Create.Table("Students")
                   .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                   .WithColumn("FullName").AsString(100).NotNullable()
                   .WithColumn("NationalCode").AsString(10).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Students");
        }
    }
}

