using System;
using Entities.Teacher;
using Entities.TeacherCourse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistanceEF.Teacher
{
    public class TeacherEntityMap : IEntityTypeConfiguration<TeacherModel>
    {


        public void Configure(EntityTypeBuilder<TeacherModel> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey("Id");

            builder.Property("Id").IsRequired().ValueGeneratedOnAdd();
            builder.Property("FirstName").IsRequired().HasMaxLength(50);
            builder.Property("LastName").IsRequired().HasMaxLength(50);
            builder.Property("Code").IsRequired();

            //builder.HasMany<TeacherCourseModel>(_ => _.TeacherCourses)
            //        .WithOne(_ => _.Teacher)
            //        .HasForeignKey(_ => _.TeacherId)
            //        .OnDelete(DeleteBehavior.SetNull);

        }
    }
}

