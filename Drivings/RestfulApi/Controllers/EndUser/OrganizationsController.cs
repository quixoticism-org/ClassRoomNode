using System.Net;
using Application.Drivings.UseCases.EndUser;
using Application.Drivings.UseCases.EndUser.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Keys;
using RestfulApi.Models;

namespace RestfulApi.Controllers.EndUser;

public class OrganizationsController : ControllerBase
{
    public OrganizationsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOrganizationBody body)
    {
        var accessToken = (HttpContext.Items[nameof(AccessToken)] as string)!;
        
        var orgRes = await Mediator.Send(new CreateOrganizationCommand
        {
            AccessToken = accessToken,
            Body = body,
        });

        return Ok(new MyResponse<OrganizationPreviewRes>
        {
            Message = "Success",
            Code = HttpStatusCode.Created,
            Payload = orgRes
        });
    }
}