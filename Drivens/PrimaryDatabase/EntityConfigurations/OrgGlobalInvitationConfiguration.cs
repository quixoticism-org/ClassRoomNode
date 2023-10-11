using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations;

internal class OrgGlobalInvitationConfiguration : BaseEntityConfiguration<OrgGlobalInvitation, OrgGlobalInvitationId>
{
    public override void Configure(EntityTypeBuilder<OrgGlobalInvitation> builder)
    {
        base.Configure(builder);
        
        builder
            .Property(o => o.OrganizationId)
            .HasConversion(
                invId => invId.Val,
                invIdVal => new(invIdVal));
        
        builder
            .Property(o => o.Code)
            .HasConversion(
                code => code.Val,
                codeVal => new(codeVal));
        
        builder
            .Property(o => o.ExpireInDay)
            .HasConversion(
                day => day.Val,
                dayVal => new(dayVal))
            .HasColumnType("smallint");

        builder
            .HasOne(o => o.Organization)
            .WithMany(o => o.OrgGlobalInvitationList)
            .HasForeignKey(o => o.OrganizationId);
    }
}