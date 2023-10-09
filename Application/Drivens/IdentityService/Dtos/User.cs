using Application.Drivens.IdentityService.Enums;

namespace Application.Drivens.IdentityService.Dtos;

public record User(string Id, Role Role);