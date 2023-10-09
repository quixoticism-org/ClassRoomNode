using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public class ClassRoom : BaseEntity<ClassRoomId>
{
    public required OrganizationId OrganizationId { get; init; }

    public required OrgMemberId OrgMemberCreatorId { get; init; }

    public required ClassRoomName Name { get; set; }

    #region RelationShips

    public Organization? Organization { get; init; }

    public OrgMember? OrgMemberCreator { get; init; }

    public List<ClassMember>? ClassMemberList { get; init; }

    #endregion
}