namespace Application.Domain.ValueObjects;

public record InvitationCode(Guid Val)
{
    public static InvitationCode New()
        => new InvitationCode(Guid.NewGuid());
}