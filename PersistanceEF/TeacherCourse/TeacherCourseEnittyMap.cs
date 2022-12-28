using System;
using Entities.TeacherCourse;
using Microsoft.EntityFrameworkCore;

namespace PersistanceEF.TeacherCourse
{
    public class TeacherCourseEnittyMap : IEntityTypeConfiguration<TeacherCourseModel>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TeacherCourseModel> builder)
        {
            builder.ToTable("TeacherCourses");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.TeacherId);
            builder.Property(_ => _.CourseId);
        }

    }
}

