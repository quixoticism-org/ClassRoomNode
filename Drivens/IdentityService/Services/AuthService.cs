using Application.Drivens.IdentityService.Dtos;
using Application.Drivens.IdentityService.Enums;
using Application.Drivens.IdentityService.Services;

namespace IdentityService.Services;

public record AuthService : IAuthService
{
    public void ThrowIfUnauthorized(string accessToken, Role allowedRole, out AuthorInfo info)
    {
        // TODO shit here
        info = new AuthorInfo
        {
            Id = "dsdsadsa"
        };
    }
}