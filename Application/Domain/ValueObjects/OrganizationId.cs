namespace Application.Domain.ValueObjects;

public record OrganizationId(Guid Val) : BaseGuidId(Val);