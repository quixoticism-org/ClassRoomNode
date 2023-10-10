using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.PrimaryDatabase.Repositories;

namespace Database.Repositories;

public class ClassMemberRepository : BaseRepository<ClassMember, ClassMemberId>, IClassMemberRepository
{
    public ClassMemberRepository(PrimaryDbContext dbContext) : base(dbContext)
    {
    }
}