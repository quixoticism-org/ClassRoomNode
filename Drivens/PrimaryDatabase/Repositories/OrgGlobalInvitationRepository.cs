using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.PrimaryDatabase.Repositories;

namespace Database.Repositories;

public class OrgGlobalInvitationRepository : BaseRepository<OrgGlobalInvitation, OrgGlobalInvitationId>, IOrgGlobalInvitationRepository
{
    public OrgGlobalInvitationRepository(PrimaryDbContext dbContext) : base(dbContext)
    {
    }
}