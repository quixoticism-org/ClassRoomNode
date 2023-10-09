using Application.Domain.Entities;
using Application.Domain.ValueObjects;

namespace Application.Drivens.MainDatabase.Repositories;

public interface IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : BaseGuidId
{
    // Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    // TODO DeleteAsync
    // TODO UpdateAsync
    // TODO GetByIdAsync
    // TODO GetManyAsync

    Task<TEntity?> GetSingleAsync(TId id, CancellationToken cancelToken = default);
    
    Task TrackAsync(TEntity entity, CancellationToken cancelToken = default);
    
    Task TrackManyAsync(IEnumerable<TEntity> entities, CancellationToken cancelToken = default);
}