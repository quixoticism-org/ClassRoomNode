using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations;

internal abstract class BaseEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TId>
    where TId : BaseGuidId
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .HasConversion(
                id => id.Val,
                idVal => (TId)Activator.CreateInstance(typeof(TId), new object[] { idVal })!);

        builder
            .Property(e => e.CreatedAt)
            .HasColumnType("timestamp");
        
        builder
            .Property(e => e.UpdatedAt)
            .IsRequired(false)
            .HasColumnType("timestamp");
    }
}