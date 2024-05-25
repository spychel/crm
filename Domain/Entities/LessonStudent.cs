namespace Domain.Entities;

public class LessonStudent
{
    #region Columns

    /// <summary>
    /// Идент. занятия
    /// </summary>
    public Guid LessonUid { get; init; }

    /// <summary>
    /// Идент. ученика
    /// </summary>
    public Guid StudentUid { get; init; }

    #endregion

    #region Relations

    /// <inheritdoc cref="Entities.Lesson"/>
    public required Lesson Lesson { get; set; }

    /// <inheritdoc cref="Entities.Student"/>
    public required Student Student { get; set; }

    #endregion
}
