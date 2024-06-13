namespace Services.Shared.DTO.Student;

public class StudentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Uid { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = string.Empty;
}
