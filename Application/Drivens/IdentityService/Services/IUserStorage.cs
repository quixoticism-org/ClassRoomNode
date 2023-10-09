using Application.Drivens.IdentityService.Dtos;
using Application.Drivens.IdentityService.Enums;

namespace Application.Drivens.IdentityService.Services;

public interface IUserStorage
{
    Task<User?> GetByIdAndRoleAsync(string id, Role role, CancellationToken cancelToken = default);
}