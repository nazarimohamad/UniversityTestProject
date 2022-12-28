using System;
using System.Data;
using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(202212271644)]
    public class _202212271644_create_teacher_table : Migration
    {
        public override void Up()
        {
            Create.Table("Teachers")
                   .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                   .WithColumn("Code").AsInt32()
                   .WithColumn("FirstName").AsString(50)
                   .WithColumn("LastName").AsString(50);

            Create.Table("TeacherCourses")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()

                  .WithColumn("TeacherId").AsInt32().Nullable()
                                .ForeignKey(
                                        foreignKeyName: "FK_Teachers_Courses",
                                        primaryTableName: "Teachers",
                                        primaryColumnName: "Id"
                                    ).OnDelete(Rule.SetNull)

                  .WithColumn("CourseId").AsInt32().Nullable()
                                .ForeignKey(
                                        foreignKeyName: "FK_Courses_Teacher",
                                        primaryTableName: "Courses",
                                        primaryColumnName: "Id"
                                    ).OnDelete(Rule.SetNull);
                    
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Teachers_Courses").OnTable("Teachers");
            Delete.ForeignKey("FK_Courses_Teacher").OnTable("Courses");
            Delete.Table("Teachers");
        }

    }
}

