using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.DrugCategory;
using DrDoc.Entities.Dto.FoodCategory;

namespace DrDoc.Services.Abstracts;

public interface IFoodCategoryService
{
    Task<IListResult<List<FoodCategoryGetDto>>> GetAllFoodCategory(
        CancellationToken cancellationToken);
    Task<IDataResult<FoodCategoryGetDto>> AddFoodCategory(
        CurrentUserDto currentUser,FoodCategoryAddDto foodCategoryAddDto,CancellationToken cancellationToken);

}