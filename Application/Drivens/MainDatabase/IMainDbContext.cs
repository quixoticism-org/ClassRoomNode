using Application.Drivens.MainDatabase.Repositories;

namespace Application.Drivens.MainDatabase;

public interface IMainDbContext
{
    public IOrganizationRepository OrganizationRepo { get; init; }
    public IOrgMemberRepository OrgMemberRepo { get; init; }
    public IClassRoomRepository ClassRoomRepo { get; init; }
    public IClassMemberRepository ClassMemberRepo { get; init; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}