using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Drug;

namespace DrDoc.Services.Abstracts;

public interface IDrugService
{
    Task<IListResult<List<DrugGetDto>>> GetAllDrug(CancellationToken cancellationToken);
    Task<IListResult<List<DrugGetDto>>> GetAllDrugByCategoryId(int drugCategoryId, CancellationToken cancellationToken);

    Task<IDataResult<DrugGetDto>> AddDrug(CurrentUserDto currentUser, DrugAddDto drugAddDto,
        CancellationToken cancellationToken);
}