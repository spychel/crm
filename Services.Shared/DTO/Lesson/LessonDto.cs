using Services.Shared.DTO.Student;

namespace Services.Shared.DTO.Lesson;

public class LessonDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Guid Uid { get; set; }

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
    /// Тип занятия
    /// </summary>
    public required LessonTypeDto Type { get; set; }

    /// <summary>
    /// Состояние занятия
    /// </summary>
    public required LessonStateTypeDto StateType { get; set; }

    /// <summary>
    /// Ученики
    /// </summary>
    public ICollection<StudentDto> Students { get; set; } = [];
}
