using DrDoc.Common.Entities.Entities;
using DrDoc.Common.Utilities.Security.Jwt;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Referrals;
using DrDoc.Services.Abstracts;
using DrDoc.WebFramework.Api;
using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebApi.Controllers.v1;

[ApiVersion("1")]
public class ReferralsController : BaseController
{
    private readonly IReferralsService _referralsService;


    public ReferralsController(IHttpContextAccessor httpContextAccessor, IReferralsService referralsService) : base(
        httpContextAccessor)
    {
        _referralsService = referralsService;
    }


    [HttpGet("[action]/{userId:int}")]
    public async Task<IActionResult> GetReferralsByUserId(
        CancellationToken cancellationToken, int userId)
    {
        var result =
            await _referralsService.GetReferralsByUserId(CurrentUser, userId, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetReferralsByPeriod(
        [FromQuery] DatePeriod datePeriod,
        CancellationToken cancellationToken)
    {
        var result =
            await _referralsService.GetReferralsByPeriod(CurrentUser, datePeriod, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> SubmitReferrals(
        [FromBody] ReferralsAddDto referralsAddDto,
        CancellationToken cancellationToken)
    {
        var result =
            await _referralsService.SubmitReferrals(CurrentUser, referralsAddDto, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}