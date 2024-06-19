namespace Services.Shared.DTO.Lesson;

public class LessonTypeDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Uid { get; set; }

    public required string Name { get; set; }
}