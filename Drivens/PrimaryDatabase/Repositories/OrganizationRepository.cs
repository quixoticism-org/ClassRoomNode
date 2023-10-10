using Application.Domain.Entities;
using Application.Domain.ValueObjects;
using Application.Drivens.PrimaryDatabase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class OrganizationRepository : BaseRepository<Organization, OrganizationId>, IOrganizationRepository
{
    public OrganizationRepository(PrimaryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsExist(OrganizationName name, CancellationToken cancelToken = default)
    {
        var matchOrg = await Source.FirstOrDefaultAsync(o => o.Name == name, cancelToken);
        return matchOrg != null;
    }
}