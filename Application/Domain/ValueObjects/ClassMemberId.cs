namespace Application.Domain.ValueObjects;

public record ClassMemberId(Guid Val) : BaseGuidId(Val);