using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public class Organization : BaseEntity<OrganizationId>
{
    public required UserId UserCreatorId { get; init; }

    public required OrganizationName Name { get; set; }

    #region RelationShips

    public List<OrgMember>? MemberList { get; init; }

    public List<ClassRoom>? ClassRoomList { get; init; }

    #endregion
}