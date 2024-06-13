namespace Services.Shared.DTO.Lesson;

public class CreateLessonDto
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
    public required Guid LessonTypeUid { get; set; }
}
