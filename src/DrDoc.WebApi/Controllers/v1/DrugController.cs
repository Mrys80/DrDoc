using DrDoc.Entities.Dto.Drug;
using DrDoc.Entities.Dto.DrugCategory;
using DrDoc.Entities.Dto.FoodCategory;
using DrDoc.Services.Abstracts;
using DrDoc.WebFramework.Api;
using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebApi.Controllers.v1;

public class DrugController:BaseController
{
    private readonly IDrugService _drugService;
    private readonly IDrugCategoryService _drugCategoryService;

    
    public DrugController(IHttpContextAccessor httpContextAccessor, IDrugService drugService, IDrugCategoryService drugCategoryService) : base(httpContextAccessor)
    {
        _drugService = drugService;
        _drugCategoryService = drugCategoryService;
    }
    
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllDrug(
        CancellationToken cancellationToken)
    {
        var result =
            await _drugService.GetAllDrug(cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
    
    [HttpGet("[action]/{drugCategoryId:Int}")]
    public async Task<IActionResult> GetAllDrugByCategoryId(
        int drugCategoryId,
        CancellationToken cancellationToken
    )
    {
        var result =
            await _drugService.GetAllDrugByCategoryId(
                drugCategoryId, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddDrug(
        DrugAddDto drugAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _drugService.AddDrug(
                CurrentUser, drugAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllDrugCategories(
        CancellationToken cancellationToken)
    {
        var result =
            await _drugCategoryService.GetAllDrugCategories(cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddDrugCategories(
        DrugCategoryAddDto drugCategoryAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _drugCategoryService.AddDrugCategories(
                CurrentUser, drugCategoryAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}