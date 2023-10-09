using Application.Domain.ValueObjects;

namespace Application.Domain.Entities;

public class ClassMember : BaseEntity<ClassMemberId>
{
    public required ClassRoomId ClassRoomId { get; init; }

    public required OrgMemberId OrgMemberId { get; init; }

    public required ClassMemberRole Role { get; init; }
    
    #region RelationShips

    public ClassRoom? ClassRoom { get; init; }

    public OrgMember? OrgMember { get; init; }

    #endregion
}