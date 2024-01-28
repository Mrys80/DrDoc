using System.Security.Claims;
using DrDoc.Common.Utilities.Constants;
using DrDoc.Common.Utilities.Extensions;
using DrDoc.Entities.Dto;
using DrDoc.WebFramework.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebFramework.Api;

[Authorize]
[ServiceFilter(typeof(SessionValidatorAttribute))]
public class BaseController : BaseSimpleController
{
    protected readonly CurrentUserDto CurrentUser;

    public BaseController(IHttpContextAccessor httpContextAccessor)
    {
        var claims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        var userId = claims.FindFirst(ClaimTypes.NameIdentifier).Value.ToInt();
        var username = claims.FindFirst(ClaimTypes.Name).Value;
        var role = claims.FindFirst(ClaimTypes.Role).Value;
        var sessionId = claims.FindFirst(Constants.SessionId).Value;
        CurrentUser = new CurrentUserDto { UserId = userId, Username = username, Role = role, SessionId = sessionId};
    }
}