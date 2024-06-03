using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Configuration;

internal class LessonTypeConfiguration : IEntityTypeConfiguration<LessonType>
{
    public void Configure(EntityTypeBuilder<LessonType> builder)
    {
        builder.ToTable("lesson_type");

        #region Columns

        builder.HasKey(e => e.Uid).HasName("lesson_type__pk");

        builder.Property(e => e.Uid)
            .IsRequired()
            .HasColumnName("uid");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasConversion(new LessonTypeNameConverter())
            .HasColumnName("name");

        #endregion
    }
}

internal class LessonTypeNameConverter : ValueConverter<LessonTypeName, string>
{
    public LessonTypeNameConverter()
        : base(
            e => LessonTypeNameHelper.ConvertToDbString(e),
            e => LessonTypeNameHelper.ConvertFromDbString(e))
    {
    }
}

public static class LessonTypeNameHelper
{
    /// <inheritdoc cref="LessonTypeName.Group"/>
    public const string Group = "group";

    /// <inheritdoc cref="LessonTypeName.Individual"/>
    public const string Individual = "individual";

    public static string ConvertToDbString(this LessonTypeName name) =>
        name switch
        {
            LessonTypeName.Group => Group,
            LessonTypeName.Individual => Individual,
            _ => throw new Exception($"{nameof(LessonTypeName)} с name = '{name}' не найден.")
        };

    public static LessonTypeName ConvertFromDbString(string name) =>
        name switch
        {
            Group => LessonTypeName.Group,
            Individual => LessonTypeName.Individual,
            _ => throw new Exception($"{nameof(LessonTypeName)} с name = '{name}' не найден.")
        };
}
