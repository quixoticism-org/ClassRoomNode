using Application.Drivens.PrimaryDatabase.Repositories;

namespace Application.Drivens.PrimaryDatabase;

public interface IPrimaryDbContext
{
    public IOrganizationRepository OrganizationRepo { get; init; }
    public IOrgMemberRepository OrgMemberRepo { get; init; }
    public IClassRoomRepository ClassRoomRepo { get; init; }
    public IClassMemberRepository ClassMemberRepo { get; init; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}