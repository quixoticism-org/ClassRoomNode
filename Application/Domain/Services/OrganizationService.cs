using Application.Domain.Entities;
using Application.Domain.Exceptions;
using Application.Domain.ValueObjects;
using Application.Drivens.IdentityService.Enums;
using Application.Drivens.IdentityService.Services;
using Application.Drivens.PrimaryDatabase;

namespace Application.Domain.Services;

public interface IOrganizationService
{
    Task<Organization> CreateOrganizationAsync(
        UserId userCreatorId,
        OrganizationName name,
        ICollection<Email> guestEmailList,
        CancellationToken cancelToken = default);
}

public record OrganizationService : IOrganizationService
{
    private readonly IPrimaryDbContext _dbCtx;
    private readonly IUserStorage _userStorage;
    
    public OrganizationService(IPrimaryDbContext dbCtx, IUserStorage userStorage)
    {
        _dbCtx = dbCtx;
        _userStorage = userStorage;
    }

    public async Task<Organization> CreateOrganizationAsync(UserId userCreatorId, OrganizationName name, ICollection<Email> guestEmailList, CancellationToken cancelToken = default)
    {
        var user = await _userStorage.GetByIdAndRoleAsync(userCreatorId.Val, Role.EndUser, cancelToken);
        if (user is null)
            throw new UserCreatorNotFoundExc();

        var isOrgExist = await _dbCtx.OrganizationRepo.IsExist(name, cancelToken);
        if (isOrgExist)
            throw new OrganizationExistExc();

        var newOrg = new Organization
        {
            UserCreatorId = userCreatorId,
            Name = name,
            InvitationList = new ()
        };
        
        newOrg.InvitationList.AddRange(guestEmailList.Select(email => new Invitation
        {
            OrganizationId = newOrg.Id,
            UserEmail = email,
            Code = InvitationCode.New()
        }));
        
        return newOrg;
    }
}