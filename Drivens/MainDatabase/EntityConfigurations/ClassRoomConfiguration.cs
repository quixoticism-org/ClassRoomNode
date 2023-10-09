using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations;

internal class ClassRoomConfiguration : BaseEntityConfiguration<ClassRoom, ClassRoomId>
{
    public override void Configure(EntityTypeBuilder<ClassRoom> builder)
    {
        base.Configure(builder);

        builder
            .Property(c => c.OrganizationId)
            .HasConversion(
                orgId => orgId.Val,
                orgIdVal => new(orgIdVal));

        builder
            .Property(c => c.OrgMemberCreatorId)
            .HasConversion(
                creatorId => creatorId.Val,
                creatorIdVal => new(creatorIdVal));
        
        builder
            .Property(c => c.Name)
            .HasConversion(
                name => name.Val,
                nameVal => new(nameVal));

        builder
            .HasOne(c => c.Organization)
            .WithMany(o => o.ClassRoomList)
            .HasForeignKey(c => c.OrganizationId);

        builder
            .HasOne(c => c.OrgMemberCreator)
            .WithMany(o => o.MyCreatedClassRoomList)
            .HasForeignKey(c => c.OrgMemberCreatorId);

        builder
            .HasMany(c => c.ClassMemberList)
            .WithOne(c => c.ClassRoom)
            .HasForeignKey(c => c.ClassRoomId);
    }
}