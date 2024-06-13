namespace Services.Shared.DTO.Lesson;

public class LessonStateTypeDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Uid { get; set; }

    public required string Name { get; set; }
}