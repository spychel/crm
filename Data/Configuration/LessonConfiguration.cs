using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lesson");

        #region Columns

        builder.HasKey(e => e.Uid).HasName("lesson__pk");

        builder.Property(e => e.Uid)
            .ValueGeneratedOnAdd()
            .HasColumnName("uid");

        builder.Property(e => e.StartingTime)
            .IsRequired()
            .HasColumnName("starting_time");

        builder.Property(e => e.Duration)
            .IsRequired()
            .HasColumnName("duration");

        builder.Property(e => e.LessonStateTypeUid)
            .IsRequired()
            .HasColumnName("lesson_state_type_uid");

        builder.Property(e => e.LessonTypeUid)
            .IsRequired()
            .HasColumnName("lesson_type_uid");

        #endregion

        #region Relations

        builder.HasOne(e => e.Type)
           .WithMany()
           .HasForeignKey(e => e.LessonTypeUid);

        builder.HasOne(e => e.StateType)
           .WithMany()
           .HasForeignKey(e => e.LessonStateTypeUid);

        builder.HasMany(e => e.LessonStudents)
            .WithOne(e => e.Lesson)
            .HasForeignKey(e => e.LessonUid);

        #endregion
    }
}
