using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.DiseaseCategory;
using DrDoc.Entities.Dto.DrugCategory;

namespace DrDoc.Services.Abstracts;

public interface IDiseaseCategoryService
{
    Task<IListResult<List<DiseaseCategoryGetDto>>> GetAllDiseaseCategory(
        CancellationToken cancellationToken);

    Task<IDataResult<DiseaseCategoryGetDto>> AddDiseaseCategory(
        CurrentUserDto currentUser, DiseaseCategoryAddDto diseaseCategoryAddDto, CancellationToken cancellationToken);
}