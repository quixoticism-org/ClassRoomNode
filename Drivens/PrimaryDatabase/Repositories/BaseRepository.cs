using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.PrimaryDatabase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : BaseGuidId
{
    protected readonly PrimaryDbContext DbContext;
    protected readonly DbSet<TEntity> Source;

    protected BaseRepository(PrimaryDbContext dbContext)
    {
        DbContext = dbContext;
        Source = dbContext.Set<TEntity>();
    }

    public Task<TEntity?> GetSingleAsync(TId id, CancellationToken cancelToken = default)
    {
        return Source.SingleOrDefaultAsync(e => e.Id == id, cancelToken);
    }

    public async Task TrackAsync(TEntity entity, CancellationToken cancelToken = default)
    {
        await Source.AddAsync(entity, cancelToken);
    }

    public async Task TrackManyAsync(IEnumerable<TEntity> entities, CancellationToken cancelToken = default)
    {
        await Source.AddRangeAsync(entities, cancelToken);
    }
}