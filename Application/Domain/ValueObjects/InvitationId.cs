namespace Application.Domain.ValueObjects;

public record InvitationId(Guid Val) : BaseGuidId(Val);