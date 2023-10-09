using Microsoft.AspNetCore.Mvc.Filters;
using RestfulApi.Keys;

namespace RestfulApi.Filters;

public record ParseAccessTokenFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var authHeaderArr = context.HttpContext.Request.Headers.Authorization.ToString().Split();
        var accessToken = authHeaderArr.Length == 2 ? authHeaderArr[1] : "";
        context.HttpContext.Items[nameof(AccessToken)] = accessToken;
    }
    
    public void OnActionExecuted(ActionExecutedContext context)
    { }
}