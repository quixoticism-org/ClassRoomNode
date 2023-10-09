using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.MainDatabase.Repositories;

namespace Database.Repositories;

public class ClassMemberRepository : BaseRepository<ClassMember, ClassMemberId>, IClassMemberRepository
{
    public ClassMemberRepository(MainDbContext dbContext) : base(dbContext)
    {
    }
}