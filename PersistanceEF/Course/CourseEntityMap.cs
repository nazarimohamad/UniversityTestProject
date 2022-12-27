using System;
using Entities.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistanceEF.Course
{
    public class CourseEntityMap : IEntityTypeConfiguration<CourseModel>
    {

        public void Configure(EntityTypeBuilder<CourseModel> builder)
        {
            builder.ToTable("Course");

            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(_ => _.Title).IsRequired().HasMaxLength(100);
        }
    }
}

