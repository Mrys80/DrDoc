using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Drug;
using DrDoc.Entities.Dto.Food;

namespace DrDoc.Services.Abstracts;

public interface IFoodService
{
    Task<IListResult<List<FoodGetDto>>> GetAllFood(CancellationToken cancellationToken);

    Task<IListResult<List<FoodGetDto>>> GetAllFoodByCategoryId(
        int foodCategoryId, CancellationToken cancellationToken);

    Task<IDataResult<FoodGetDto>> AddFood(
        CurrentUserDto currentUser, FoodAddDto foodAddDto,
        CancellationToken cancellationToken);
}