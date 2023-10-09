using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public class OrgMember : BaseEntity<OrgMemberId>
{
    public required UserId UserId { get; init; }
    
    public required OrganizationId OrganizationId { get; init; }

    #region RelationShips

    public Organization? Organization { get; init; }

    public List<ClassRoom>? MyCreatedClassRoomList { get; init; }
    
    public List<ClassMember>? ClassMemberList { get; init; }
    
    #endregion
}