using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class LessonStudentConfiguration : IEntityTypeConfiguration<LessonStudent>
{
    public void Configure(EntityTypeBuilder<LessonStudent> builder)
    {
        builder.ToTable("lesson_student");

        #region Columns

        builder.HasKey(sl => new { sl.LessonUid, sl.StudentUid }).HasName("lesson_student__pk");

        builder.Property(e => e.LessonUid)
            .IsRequired()
            .HasColumnName("lesson_uid");

        builder.Property(e => e.StudentUid)
            .IsRequired()
            .HasColumnName("student_uid");

        #endregion
    }
}
