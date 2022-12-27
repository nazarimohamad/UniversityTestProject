using System;
using Entities.Semesters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistanceEF.Semsters
{
    public class SemesterEntityMap : IEntityTypeConfiguration<SemesterModel>
    {
        public SemesterEntityMap()
        {
        }

        public void Configure(EntityTypeBuilder<SemesterModel> builder)
        {
            builder.ToTable("Semester");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.Number).IsRequired();
            builder.Property(_ => _.Year).IsRequired();
        }
    }
}

