using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.MainDatabase.Repositories;

namespace Database.Repositories;

public class OrgMemberRepository : BaseRepository<OrgMember, OrgMemberId>, IOrgMemberRepository
{
    public OrgMemberRepository(MainDbContext dbContext) : base(dbContext)
    {
    }
}