using Entities.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistanceEF.Student
{
    public class StudentEntityMap : IEntityTypeConfiguration<StudentModel>
    {
        public StudentEntityMap()
        {
        }

        public void Configure(EntityTypeBuilder<StudentModel> builder)
        {
            builder.ToTable("Students");

            builder.HasKey("Id");

            builder.Property("Id").IsRequired().ValueGeneratedOnAdd();
            builder.Property("FullName").IsRequired().HasMaxLength(100);
            builder.Property("NationalCode").IsRequired().HasMaxLength(10);
        }
    }
}

