using Domain.Enums;

namespace Domain.Entities;

public class LessonType : BaseEntity
{
    public LessonTypeName Name { get; set; }
}