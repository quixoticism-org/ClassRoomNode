using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations;

internal class ClassMemberConfiguration : BaseEntityConfiguration<ClassMember, ClassMemberId>
{
    public override void Configure(EntityTypeBuilder<ClassMember> builder)
    {
        base.Configure(builder);

        builder
            .Property(c => c.ClassRoomId)
            .HasConversion(
                classRoomId => classRoomId.Val,
                classRoomIdVal => new(classRoomIdVal));
        
        builder
            .Property(c => c.OrgMemberId)
            .HasConversion(
                orgMemberId => orgMemberId.Val,
                orgMemberIdVal => new(orgMemberIdVal));

        builder
            .Property(c => c.Role)
            .HasConversion<int>();

        builder
            .HasOne(c => c.ClassRoom)
            .WithMany(c => c.ClassMemberList)
            .HasForeignKey(c => c.ClassRoomId);

        builder
            .HasOne(c => c.OrgMember)
            .WithMany(o => o.ClassMemberList)
            .HasForeignKey(c => c.OrgMemberId);
    }
}