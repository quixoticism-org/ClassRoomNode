namespace Application.Domain.ValueObjects;

public record OrgMemberId(Guid Val) : BaseGuidId(Val);