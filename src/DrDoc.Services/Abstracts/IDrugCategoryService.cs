using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.DrugCategory;

namespace DrDoc.Services.Abstracts;

public interface IDrugCategoryService
{
    Task<IListResult<List<DrugCategoryGetDto>>> GetAllDrugCategories(CancellationToken cancellationToken);
    Task<IDataResult<DrugCategoryGetDto>> AddDrugCategories(CurrentUserDto currentUser,DrugCategoryAddDto drugCategoryAddDto,CancellationToken cancellationToken);
}