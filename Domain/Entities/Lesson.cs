namespace Domain.Entities;

public class Lesson : BaseEntity
{
    public IEnumerable<Student> Students { get; set; }
    public LessonType Type { get; set; }
    public LessonState State { get; set; }

}
