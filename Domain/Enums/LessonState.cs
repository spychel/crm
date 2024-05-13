namespace Domain.Enums;

public enum LessonState
{
    /// <summary>
    /// Занятие назначено
    /// </summary>
    Appointed,
    /// <summary>
    /// Занятие проведено
    /// </summary>
    Completed,
    /// <summary>
    /// Занятие перенесено
    /// </summary>
    Rescheduled,
    /// <summary>
    /// Занятие отменено
    /// </summary>
    Dismissed
}