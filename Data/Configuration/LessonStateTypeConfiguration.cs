using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Configuration;

internal class LessonStateTypeConfiguration : IEntityTypeConfiguration<LessonStateType>
{
    public void Configure(EntityTypeBuilder<LessonStateType> builder)
    {
        builder.ToTable("lesson_state_type");

        #region Columns

        builder.HasKey(e => e.Uid).HasName("lesson_state_type__pk");

        builder.Property(e => e.Uid)
            .ValueGeneratedOnAdd()
            .HasColumnName("uid");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasConversion<LessonStateTypeNameConverter>()
            .HasColumnName("name");

        #endregion
    }
}

internal class LessonStateTypeNameConverter : ValueConverter<string, LessonStateTypeName>
{
    public LessonStateTypeNameConverter()
        : base(
            e => LessonStateTypeNameHelper.ConvertFromDbString(e),
            e => LessonStateTypeNameHelper.ConvertToDbString(e))
    {
    }
}

public static class LessonStateTypeNameHelper
{
    /// <inheritdoc cref="LessonStateTypeName.Appointed"/>
    public const string Appointed = "appointed";

    /// <inheritdoc cref="LessonStateTypeName.Completed"/>
    public const string Completed = "completed";

    /// <inheritdoc cref="LessonStateTypeName.Dismissed"/>
    public const string Dismissed = "dismissed";

    /// <inheritdoc cref="LessonStateTypeName.Rescheduled"/>
    public const string Rescheduled = "rescheduled";

    public static string ConvertToDbString(this LessonStateTypeName name) =>
        name switch
        {
            LessonStateTypeName.Appointed => Appointed,
            LessonStateTypeName.Completed => Completed,
            LessonStateTypeName.Dismissed => Dismissed,
            LessonStateTypeName.Rescheduled => Rescheduled,
            _ => throw new Exception($"{nameof(LessonStateTypeName)} с name = '{name}' не найден.")
        };


    public static LessonStateTypeName ConvertFromDbString(string name) =>
        name switch
        {
            Appointed => LessonStateTypeName.Appointed,
            Completed => LessonStateTypeName.Completed,
            Dismissed => LessonStateTypeName.Dismissed,
            Rescheduled => LessonStateTypeName.Rescheduled,
            _ => throw new Exception($"{nameof(LessonStateTypeName)} с name = '{name}' не найден.")
        };
}
