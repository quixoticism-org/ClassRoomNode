using System.Net;

namespace RestfulApi.Models;

public record MyResponse
{
    public required string Message { get; init; }
    public required HttpStatusCode Code { get; init; }

    public Dictionary<string, string>? Errors { get; set; } = default;
}

public record MyResponse<TPayload> : MyResponse
{
    public required TPayload Payload { get; init; }
}