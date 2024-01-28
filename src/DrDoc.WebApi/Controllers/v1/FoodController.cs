using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Disease;
using DrDoc.Entities.Dto.DiseaseCategory;
using DrDoc.Entities.Dto.Food;
using DrDoc.Entities.Dto.FoodCategory;
using DrDoc.Services.Abstracts;
using DrDoc.WebFramework.Api;
using Microsoft.AspNetCore.Mvc;

namespace DrDoc.WebApi.Controllers.v1;

[ApiVersion("1")]
public class FoodController : BaseController
{
    private readonly IFoodService _foodService;
    private readonly IFoodCategoryService _foodCategoryService;


    public FoodController(IHttpContextAccessor httpContextAccessor, IFoodService foodService,
        IFoodCategoryService foodCategoryService) : base(httpContextAccessor)
    {
        _foodService = foodService;
        _foodCategoryService = foodCategoryService;
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllFood(
        CancellationToken cancellationToken)
    {
        var result =
            await _foodService.GetAllFood(cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]/{foodCategoryId:Int}")]
    public async Task<IActionResult> GetAllFoodByCategoryId(
        int foodCategoryId,
        CancellationToken cancellationToken
    )
    {
        var result =
            await _foodService.GetAllFoodByCategoryId(
                foodCategoryId, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddFood(
        FoodAddDto foodAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _foodService.AddFood(
                CurrentUser, foodAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllFoodCategory(
        CancellationToken cancellationToken)
    {
        var result =
            await _foodCategoryService.GetAllFoodCategory(cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddFoodCategory(
        FoodCategoryAddDto foodCategoryAddDto, CancellationToken cancellationToken
    )
    {
        var result =
            await _foodCategoryService.AddFoodCategory(
                CurrentUser, foodCategoryAddDto, cancellationToken
            );

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}