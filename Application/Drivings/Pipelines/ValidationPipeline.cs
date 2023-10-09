using MediatR;

namespace Application.Drivings.Pipelines;

public record ValidationPipeline<TReq, TRes> 
    : IPipelineBehavior<TReq, TRes> where TReq : IBaseRequest
{
    public Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken stopToken)
    {
        // TODO
        return next();
    }
}