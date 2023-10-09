namespace Application.Domain.ValueObjects;

public record ClassRoomId(Guid Val) : BaseGuidId(Val);