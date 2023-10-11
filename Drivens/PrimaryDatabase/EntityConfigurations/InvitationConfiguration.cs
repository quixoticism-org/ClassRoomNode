using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations;

internal class InvitationConfiguration : BaseEntityConfiguration<Invitation, InvitationId>
{
    public override void Configure(EntityTypeBuilder<Invitation> builder)
    {
        base.Configure(builder);

        builder
            .Property(i => i.OrganizationId)
            .HasConversion(
                invId => invId.Val,
                invIdVal => new(invIdVal));
        
        builder
            .Property(i => i.UserEmail)
            .HasConversion(
                userEmail => userEmail.Val,
                userEmailVal => new(userEmailVal));

        builder
            .Property(i => i.Code)
            .HasConversion(
                code => code.Val,
                codeVal => new(codeVal));
        
        builder
            .HasOne(i => i.Organization)
            .WithMany(o => o.InvitationList)
            .HasForeignKey(i => i.OrganizationId);
    }
}