using Application.Drivens.IdentityService.Dtos;
using Application.Drivens.IdentityService.Enums;

namespace Application.Drivings.Requests;

public interface IAuthorizedRequest
{
    public string AccessToken { get; init; }
    
    public AuthorInfo AuthorInfo { get; set; }

    public Role GetAllowedRole();
}