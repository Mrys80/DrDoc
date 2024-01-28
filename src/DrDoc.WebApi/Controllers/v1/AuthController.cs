using DrDoc.Entities.Dto.Auth;
using DrDoc.Services.Abstracts;
using DrDoc.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebApi.Controllers.v1;

[ApiVersion("1")]
public class AuthController : BaseSimpleController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _authService.Login(loginDto, cancellationToken);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine("###### Login error ######");
            Console.WriteLine(e);
            throw;
        }
    }

    

    
}