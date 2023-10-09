using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.MainDatabase.Repositories;

namespace Database.Repositories;

public class ClassRoomRepository : BaseRepository<ClassRoom, ClassRoomId>, IClassRoomRepository
{
    public ClassRoomRepository(MainDbContext dbContext) : base(dbContext)
    {
    }
}