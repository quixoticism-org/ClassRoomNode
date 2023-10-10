using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.PrimaryDatabase.Repositories;

namespace Database.Repositories;

public class ClassRoomRepository : BaseRepository<ClassRoom, ClassRoomId>, IClassRoomRepository
{
    public ClassRoomRepository(PrimaryDbContext dbContext) : base(dbContext)
    {
    }
}