using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public class Invitation : BaseEntity<InvitationId>
{
    public required OrganizationId OrganizationId { get; init; }

    public required Email UserEmail { get; init; }

    public required InvitationCode Code { get; init; }

    #region Relationships

    public Organization? Organization { get; init; }

    #endregion
}