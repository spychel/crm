using Domain.Enums;

namespace Domain.Entities;

public class Lesson : BaseEntity
{
    /// <summary>
    /// Дата и время начала занятия
    /// </summary>
    public DateTime DateTime { get; set; }
    /// <summary>
    /// Продолжительность занятия
    /// </summary>
    public ushort Duration { get; set; }
    /// <summary>
    /// Тип занятия
    /// </summary>
    public LessonType Type { get; set; }
    /// <summary>
    /// Состояние занятия
    /// </summary>
    public LessonState State { get; set; }
    /// <summary>
    /// Ученики принимающие участие в занятии
    /// </summary>
    public IEnumerable<Student>? Students { get; set; }
    /// <summary>
    /// Оплачен ли урок
    /// </summary>
    public bool IsPaid { get; set; }
    /// <summary>
    /// Идент. связанного урока
    /// </summary>
    public Guid? LinkedLessonUid {  get; set; }
    /// <summary>
    /// Связанный урок
    /// </summary>
    public Lesson? LinkedLesson { get; set; }
}
