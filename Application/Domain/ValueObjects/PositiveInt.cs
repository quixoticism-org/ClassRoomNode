using Application.Domain.Exceptions;

namespace Application.Domain.ValueObjects;

public record PositiveInt
{
    public int Val { get; init; }

    public PositiveInt(int val)
    {
        if (Val <= 0)
            throw new InvalidPositiveInt();
        Val = val;
    }
}