using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(202212271254)]
    public class _202212271254_create_course_table : Migration
    {
        public _202212271254_create_course_table()
        {
        }

        public override void Up()
        {
            Create.Table("Courses")
                    .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                   .WithColumn("Title").AsString(100).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Courses");
        }
    }
}

