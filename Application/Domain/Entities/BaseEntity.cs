using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public abstract class BaseEntity<TId> where TId : BaseGuidId
{
    public TId Id { get; init; } = (TId)Activator.CreateInstance(typeof(TId), new object[] { Guid.NewGuid() })!;

    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = default;
}