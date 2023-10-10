using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.PrimaryDatabase.Repositories;

namespace Database.Repositories;

public class OrgMemberRepository : BaseRepository<OrgMember, OrgMemberId>, IOrgMemberRepository
{
    public OrgMemberRepository(PrimaryDbContext dbContext) : base(dbContext)
    {
    }
}