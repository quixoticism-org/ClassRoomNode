using Application.Drivens.IdentityService.Dtos;
using Application.Drivens.IdentityService.Enums;

namespace Application.Drivens.IdentityService.Services;

public interface IAuthService
{
    void ThrowIfUnauthorized(string accessToken, Role allowedRole, out AuthorInfo info);
}