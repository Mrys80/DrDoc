using DrDoc.Common.Abstracts;
using DrDoc.Common.Entities.Dto;
using DrDoc.Common.Utilities.Results;
using DrDoc.Data.Abstracts;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Drug;
using DrDoc.Entities.Dto.Food;
using DrDoc.Entities.Dto.FoodCategory;
using DrDoc.Entities.Entities;
using DrDoc.Services.Abstracts;
using Mapster;

namespace DrDoc.Services.Concretes;

public class FoodService : IFoodService, IFoodCategoryService, IScopedDependency
{
    private readonly IRepository<Food> _foodRepository;
    private readonly IRepository<FoodCategory> _foodCategoryRepository;

    public FoodService(IRepository<FoodCategory> foodCategoryRepository, IRepository<Food> foodRepository)
    {
        _foodCategoryRepository = foodCategoryRepository;
        _foodRepository = foodRepository;
    }


    public async Task<IListResult<List<FoodGetDto>>> GetAllFood(
        CancellationToken cancellationToken)
    {
        var foods = await _foodRepository
            .GetListAsync(food => food.IsDeleted == false, cancellationToken);
        var foodsDto = foods.Select(food => new FoodGetDto { Id = food.Id, Title = food.Title, ImageId = food.ImageId })
            .ToList();
        return new SuccessListResult<List<FoodGetDto>>(foodsDto);
    }

    public async Task<IListResult<List<FoodGetDto>>> GetAllFoodByCategoryId(int foodCategoryId,
        CancellationToken cancellationToken)
    {
        var foods = await _foodRepository
            .GetListAsync(
                food =>
                    food.IsDeleted == false &&
                    food.FoodCategoryId == foodCategoryId,
                cancellationToken);
        var foodsDto = foods.Select(food => new FoodGetDto { Id = food.Id, Title = food.Title, ImageId = food.ImageId })
            .ToList();
        return new SuccessListResult<List<FoodGetDto>>(foodsDto);
    }

    public async Task<IDataResult<FoodGetDto>> AddFood(CurrentUserDto currentUser, FoodAddDto foodAddDto,
        CancellationToken cancellationToken)
    {
        var food = new Food
        {
            Title = foodAddDto.Title,
            FoodCategoryId = foodAddDto.FoodCategoryId,
            ImageId = foodAddDto.ImageId,
            RegUserId = currentUser.UserId,
            RegDate = DateTime.Now,
            IsDeleted = false
        };

        await _foodRepository.AddAsync(food, cancellationToken);

        var foodDto = food.Adapt<FoodGetDto>();
        return new SuccessDataResult<FoodGetDto>(foodDto);
    }

    public async Task<IListResult<List<FoodCategoryGetDto>>> GetAllFoodCategory(CancellationToken cancellationToken)
    {
        var foodsCategory = await _foodCategoryRepository
            .GetListAsync(foodsCategory => foodsCategory.IsDeleted == false, cancellationToken);
        var foodsCategoryDto = foodsCategory.Select(foodCategory => new FoodCategoryGetDto
                { Id = foodCategory.Id, Title = foodCategory.Title, ImageId = foodCategory.ImageId })
            .ToList();
        return new SuccessListResult<List<FoodCategoryGetDto>>(foodsCategoryDto);
    }

   

    public async Task<IDataResult<FoodCategoryGetDto>> AddFoodCategory(CurrentUserDto currentUser,
        FoodCategoryAddDto foodCategoryAddDto,
        CancellationToken cancellationToken)
    {
        var foodCategory = new FoodCategory
        {
            Title = foodCategoryAddDto.Title,
            ImageId = foodCategoryAddDto.ImageId,
            RegUserId = currentUser.UserId,
            RegDate = DateTime.Now,
            IsDeleted = false
        };

        await _foodCategoryRepository.AddAsync(foodCategory, cancellationToken);

        var foodCategoryDto = foodCategory.Adapt<FoodCategoryGetDto>();
        return new SuccessDataResult<FoodCategoryGetDto>(foodCategoryDto);
    }
}