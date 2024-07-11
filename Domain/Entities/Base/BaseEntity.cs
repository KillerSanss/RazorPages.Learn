using Ardalis.GuardClauses;

namespace Domain.Entities.Base;

/// <summary>
/// Базовый класс общих полей сущностей
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Установка идентификатора
    /// </summary>
    protected void SetId(Guid id)
    {
        Id = Guard.Against.NullOrEmpty(id);
    }
}