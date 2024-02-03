using System.Threading;
using System.Threading.Tasks;
using DrDoc.Common.Entities.Dto;
using DrDoc.Entities.Dto.UserDisease;
using DrDoc.Entities.Dto.UserDrugAllergy;
using DrDoc.Entities.Dto.UserFoodAllergy;
using DrDoc.Services.Abstracts;
using DrDoc.WebFramework.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebApi.Controllers.v1;

[ApiVersion("1")]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IHttpContextAccessor httpContextAccessor, IUserService userService) : base(
        httpContextAccessor)
    {
        _userService = userService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddUser(
        UserAddDto userAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _userService.AddUser(
                CurrentUser, userAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateUser(
        UserUpdateDto userUpdateDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _userService.UpdateUser(
                userUpdateDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUser(
        [FromQuery] string nationalCode, CancellationToken cancellationToken
    )
    {
        var result =
            await _userService.GetUser(
                nationalCode, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken
    )
    {
        var result =
            await _userService.GetAllUser(cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddUserDrugAllergy(
        UserDrugAllergyAddDto userDrugAllergyAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _userService.AddUserDrugAllergy(
                CurrentUser, userDrugAllergyAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddUserFoodAllergy(
        UserFoodAllergyAddDto userFoodAllergyAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _userService.AddUserFoodAllergy(
                CurrentUser, userFoodAllergyAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddUserDisease(
        UserDiseaseAddDto userDiseaseAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _userService.AddUserDisease(
                CurrentUser, userDiseaseAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]/{userId:int}")]
    public async Task<IActionResult> GetUserDrugAllergy(
        CancellationToken cancellationToken, int userId)
    {
        var result =
            await _userService.GetUserDrugAllergy(userId, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]/{userId:int}")]
    public async Task<IActionResult> GetUserFoodAllergy(
        CancellationToken cancellationToken, int userId)
    {
        var result =
            await _userService.GetUserFoodAllergy(userId, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]/{userId:int}")]
    public async Task<IActionResult> GetUserDisease(
        CancellationToken cancellationToken, int userId)
    {
        var result =
            await _userService.GetUserDisease(userId, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}