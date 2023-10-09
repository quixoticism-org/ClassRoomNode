using Application.Drivens.IdentityService.Services;
using Application.Drivings.Requests;
using MediatR;

namespace Application.Drivings.Pipelines;

public record AuthorizationPipeline<TReq, TRes> 
    : IPipelineBehavior<TReq, TRes> where TReq : IBaseRequest
{
    private readonly IAuthService _authService;

    public AuthorizationPipeline(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken stopToken)
    {
        if (request is not IAuthorizedRequest authorizedReq) 
            return next();
        
        _authService.ThrowIfUnauthorized(
            authorizedReq.AccessToken,
            authorizedReq.GetAllowedRole(),
            out var authorInfo);
        
        authorizedReq.AuthorInfo = authorInfo;
        
        return next();
    }
}