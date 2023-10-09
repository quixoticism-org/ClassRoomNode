using Application.Drivens.IdentityService.Dtos;
using Application.Drivens.IdentityService.Enums;
using MediatR;

namespace Application.Drivings.Requests;

public abstract record AuthorizedCommandRequest<TBody, TRes> 
    : IRequest<TRes>, ICommandRequest<TBody>, IAuthorizedRequest where TBody : notnull
{
    public required TBody Body { get; init; }
    
    public required  string AccessToken { get; init; }
    
    // this will be set in AuthorizationPipeline
    public AuthorInfo AuthorInfo { get; set; } = null!;

    public abstract Role GetAllowedRole();
}