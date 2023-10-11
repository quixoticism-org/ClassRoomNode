using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.PrimaryDatabase.Repositories;

namespace Database.Repositories;

public class InvitationRepository : BaseRepository<Invitation, InvitationId>, IInvitationRepository
{
    public InvitationRepository(PrimaryDbContext dbContext) : base(dbContext)
    {
    }
}