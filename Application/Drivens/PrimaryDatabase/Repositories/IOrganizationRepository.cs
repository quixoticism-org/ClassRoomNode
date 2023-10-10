using Application.Domain.Entities;
using Application.Domain.ValueObjects;

namespace Application.Drivens.PrimaryDatabase.Repositories;

public interface IOrganizationRepository : IBaseRepository<Organization, OrganizationId>
{
    Task<bool> IsExist(OrganizationName name, CancellationToken cancelToken = default);
}