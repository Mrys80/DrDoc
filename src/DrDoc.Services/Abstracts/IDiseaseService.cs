using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Disease;

namespace DrDoc.Services.Abstracts;

public interface IDiseaseService
{
    Task<IListResult<List<DiseaseGetDto>>> GetAllDisease(
        CancellationToken cancellationToken
    );

    Task<IListResult<List<DiseaseGetDto>>> GetAllDiseaseByCategoryId(
        int diseaseCategoryId,
        CancellationToken cancellationToken
    );

    Task<IDataResult<DiseaseGetDto>> AddDisease(
        CurrentUserDto currentUser,
        DiseaseAddDto diseaseAddDto,
        CancellationToken cancellationToken
    );
    
}