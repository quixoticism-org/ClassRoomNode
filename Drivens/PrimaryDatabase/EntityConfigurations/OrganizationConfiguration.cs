using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations;

internal class OrganizationConfiguration : BaseEntityConfiguration<Organization, OrganizationId>
{
    public override void Configure(EntityTypeBuilder<Organization> builder)
    {
        base.Configure(builder);

        builder
            .HasIndex(o => o.UserCreatorId);
        
        builder
            .HasIndex(o => new
            {
                o.UserCreatorId,
                o.Name
            })
            .IsUnique();

        builder
            .Property(o => o.UserCreatorId)
            .HasConversion(
                userCreatorId => userCreatorId.Val,
                userCreatorIdVal => new (userCreatorIdVal))
            .HasColumnType("varchar");

        builder
            .Property(o => o.Name)
            .HasConversion(
                name => name.Val,
                nameVal => new(nameVal))
            .HasColumnType("varchar");

        builder
            .HasMany(o => o.MemberList)
            .WithOne(m => m.Organization)
            .HasForeignKey(m => m.OrganizationId);

        builder
            .HasMany(o => o.ClassRoomList)
            .WithOne(c => c.Organization)
            .HasForeignKey(c => c.OrganizationId);
    }
}