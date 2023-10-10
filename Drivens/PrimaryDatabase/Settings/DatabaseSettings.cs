namespace Database.Settings;

public record DatabaseSettings
{
    public required string ConnectionStr { get; init; }
}