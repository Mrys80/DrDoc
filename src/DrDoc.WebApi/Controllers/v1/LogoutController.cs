using DrDoc.Services.Abstracts;
using DrDoc.WebFramework.Api;
using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebApi.Controllers.v1;
[ApiVersion("1")]
public class LogoutController : BaseController
{
    private readonly IAuthService _authService;
    public LogoutController(IHttpContextAccessor httpContextAccessor, IAuthService authService) : base(httpContextAccessor)
    {
        _authService = authService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        var result = await _authService.Logout(CurrentUser, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}