using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student");

        #region Columns

        builder.HasKey(e => e.Uid).HasName("student__pk");

        builder.Property(e => e.Uid)
            .ValueGeneratedOnAdd()
            .HasColumnName("uid");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasColumnName("last_name");

        #endregion

        #region Relations

        builder
            .HasMany(e => e.StudentLessons)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentUid);

        #endregion
    }
}
