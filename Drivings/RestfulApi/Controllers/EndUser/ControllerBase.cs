using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApi.Controllers.EndUser;

[Route("restful-api/end-user/[controller]")]
[ApiController]
public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    protected readonly IMediator Mediator;

    protected ControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }
}