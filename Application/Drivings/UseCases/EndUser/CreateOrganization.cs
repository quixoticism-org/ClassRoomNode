using Application.Domain.Services;
using Application.Domain.ValueObjects;
using Application.Drivens.IdentityService.Enums;
using Application.Drivens.PrimaryDatabase;
using Application.Drivings.Requests;
using Application.Drivings.UseCases.EndUser.Dtos;
using MediatR;

namespace Application.Drivings.UseCases.EndUser;

public record CreateOrganizationBody(string Name, List<string> GuestEmailList);

public record CreateOrganizationCommand : AuthorizedCommandRequest<CreateOrganizationBody, OrganizationPreviewRes>
{
    public override Role GetAllowedRole() => Role.EndUser;
}

public record CreateOrganization : IRequestHandler<CreateOrganizationCommand, OrganizationPreviewRes>
{
    private readonly IOrganizationService _organizationService;
    private readonly IPrimaryDbContext _dbCtx;

    public CreateOrganization(IOrganizationService organizationService, IPrimaryDbContext dbCtx)
    {
        _organizationService = organizationService;
        _dbCtx = dbCtx;
    }

    public async Task<OrganizationPreviewRes> Handle(CreateOrganizationCommand request, CancellationToken cancelToken)
    {
        var authorUserId = new UserId(request.AuthorInfo.Id);
        var orgName = new OrganizationName(request.Body.Name);
        var newOrg = await _organizationService.CreateOrganizationAsync(authorUserId, orgName, cancelToken);
        
        await _dbCtx.OrganizationRepo.TrackAsync(newOrg, cancelToken);
        await _dbCtx.SaveChangesAsync(cancelToken);
        
        // TODO call notification service to send invitation to guest

        return new OrganizationPreviewRes(
            newOrg.Id.Val.ToString(), 
            newOrg.Name.Val);
    }
}