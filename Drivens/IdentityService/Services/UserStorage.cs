using Application.Drivens.IdentityService.Dtos;
using Application.Drivens.IdentityService.Enums;
using Application.Drivens.IdentityService.Services;

namespace IdentityService.Services;

public class UserStorage : IUserStorage
{
    public async Task<User?> GetByIdAndRoleAsync(string id, Role role, CancellationToken cancelToken = default)
    {
        await Task.CompletedTask;
        return new User("dsdsadsa", Role.EndUser);
    }
}