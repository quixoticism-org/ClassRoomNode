using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations;

internal class OrgMemberConfiguration : BaseEntityConfiguration<OrgMember, OrgMemberId>
{
    public override void Configure(EntityTypeBuilder<OrgMember> builder)
    {
        base.Configure(builder);

        builder
            .HasIndex(o => o.UserId);
        
        builder
            .Property(o => o.UserId)
            .HasConversion(
                userId => userId.Val,
                userIdVal => new (userIdVal))
            .HasColumnType("varchar");
        
        builder
            .Property(o => o.OrganizationId)
            .HasConversion(
                orgId => orgId.Val,
                orgIdVal => new (orgIdVal));

        builder
            .HasOne(o => o.Organization)
            .WithMany(o => o.MemberList)
            .HasForeignKey(o => o.OrganizationId);

        builder
            .HasMany(o => o.MyCreatedClassRoomList)
            .WithOne(c => c.OrgMemberCreator)
            .HasForeignKey(c => c.OrgMemberCreatorId);

        builder
            .HasMany(o => o.ClassMemberList)
            .WithOne(c => c.OrgMember)
            .HasForeignKey(c => c.OrgMemberId);
    }
}