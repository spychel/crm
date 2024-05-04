namespace Domain.Entities;

public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Uid { get; set; }
}
