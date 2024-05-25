namespace Domain.Entities;

/// <summary>
/// Занятие
/// </summary>
public class Lesson : BaseEntity
{
    /// <summary>
    /// Дата и время начала занятия
    /// </summary>
    public required DateTime StartingTime { get; set; }

    /// <summary>
    /// Продолжительность занятия
    /// </summary>
    public required ushort Duration { get; set; }

    /// <summary>
    /// Стоимость занятия
    /// </summary>
    public required ushort Price { get; set; }

    /// <summary>
    /// Идент. состояния занятия
    /// </summary>
    public required Guid LessonStateTypeUid { get; set; }

    /// <summary>
    /// Идент. типа занятия
    /// </summary>
    public required Guid LessonTypeUid {  get; set; }

    /// <summary>
    /// Тип занятия
    /// </summary>
    public required LessonType Type { get; set; }

    /// <summary>
    /// Состояние занятия
    /// </summary>
    public required LessonStateType StateType { get; set; }

    /// <summary>
    /// Связь учеников и урока
    /// </summary>
    public ICollection<LessonStudent> LessonStudents { get; set; } = [];
}
