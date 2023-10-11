using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public class OrgGlobalInvitation : BaseEntity<OrgGlobalInvitationId>
{
    public required OrganizationId OrganizationId { get; init; }
    
    public required InvitationCode Code { get; init; }
    
    public required PositiveInt ExpireInDay { get; init; }

    #region Relationships

    public Organization? Organization { get; init; }

    #endregion
}