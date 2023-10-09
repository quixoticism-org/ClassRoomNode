namespace Application.Drivings.Requests;

public interface ICommandRequest<TBody> where TBody : notnull
{
    public TBody Body { get; init; }
}