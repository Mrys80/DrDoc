using DrDoc.Common.Abstracts;
using DrDoc.Common.Utilities.Results;
using DrDoc.Data.Abstracts;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Disease;
using DrDoc.Entities.Dto.DiseaseCategory;
using DrDoc.Entities.Entities;
using DrDoc.Services.Abstracts;
using Mapster;

namespace DrDoc.Services.Concretes;

public class DiseaseService : IDiseaseService, IDiseaseCategoryService, IScopedDependency
{
    private readonly IRepository<Disease> _diseaseRepository;
    private readonly IRepository<DiseaseCategory> _diseaseCategoryRepository;


    public DiseaseService(IRepository<Disease> diseaseRepository,
        IRepository<DiseaseCategory> diseaseCategoryRepository)
    {
        _diseaseRepository = diseaseRepository;
        _diseaseCategoryRepository = diseaseCategoryRepository;
    }

    public async Task<IListResult<List<DiseaseGetDto>>> GetAllDisease(CancellationToken cancellationToken)
    {
        var diseases = await _diseaseRepository
            .GetListAsync(disease => disease.IsDeleted == false, cancellationToken);
        var diseasesDto = diseases.Select(disease => new DiseaseGetDto
                { Id = disease.Id, Title = disease.Title, ImageId = disease.ImageId })
            .ToList();
        return new SuccessListResult<List<DiseaseGetDto>>(diseasesDto);
    }

    public async Task<IListResult<List<DiseaseGetDto>>> GetAllDiseaseByCategoryId(int diseaseCategoryId,
        CancellationToken cancellationToken)
    {
        var diseases = await _diseaseRepository
            .GetListAsync(
                disease =>
                    disease.DiseaseCategoryId == diseaseCategoryId &&
                    disease.IsDeleted == false,
                cancellationToken);
        var diseasesDto = diseases.Select(disease => new DiseaseGetDto
                { Id = disease.Id, Title = disease.Title, ImageId = disease.ImageId })
            .ToList();
        return new SuccessListResult<List<DiseaseGetDto>>(diseasesDto);
    }

    public async Task<IDataResult<DiseaseGetDto>> AddDisease(CurrentUserDto currentUser, DiseaseAddDto diseaseAddDto,
        CancellationToken cancellationToken)
    {
        var disease = new Disease
        {
            Title = diseaseAddDto.Title,
            ImageId = diseaseAddDto.ImageId,
            DiseaseCategoryId = diseaseAddDto.DiseaseCategoryId,
            RegUserId = currentUser.UserId,
            RegDate = DateTime.Now,
            IsDeleted = false
        };

        await _diseaseRepository.AddAsync(disease, cancellationToken);

        var diseaseDto = disease.Adapt<DiseaseGetDto>();
        return new SuccessDataResult<DiseaseGetDto>(diseaseDto);
    }


    public async Task<IListResult<List<DiseaseCategoryGetDto>>> GetAllDiseaseCategory(
        CancellationToken cancellationToken)
    {
        var diseasesCategory = await _diseaseCategoryRepository
            .GetListAsync(diseasesCategory => diseasesCategory.IsDeleted == false, cancellationToken);
        var diseasesCategoryDto = diseasesCategory.Select(disease => new DiseaseCategoryGetDto
                { Id = disease.Id, Title = disease.Title, ImageId = disease.ImageId })
            .ToList();
        return new SuccessListResult<List<DiseaseCategoryGetDto>>(diseasesCategoryDto);
    }

    public async Task<IDataResult<DiseaseCategoryGetDto>> AddDiseaseCategory(CurrentUserDto currentUser,
        DiseaseCategoryAddDto diseaseCategoryAddDto, CancellationToken cancellationToken)
    {
        var diseaseCategory = new DiseaseCategory
        {
            Title = diseaseCategoryAddDto.Title,
            ImageId = diseaseCategoryAddDto.ImageId,
            RegUserId = currentUser.UserId,
            RegDate = DateTime.Now,
            IsDeleted = false
        };

        await _diseaseCategoryRepository.AddAsync(diseaseCategory, cancellationToken);

        var diseaseCategoryDto = diseaseCategory.Adapt<DiseaseCategoryGetDto>();
        return new SuccessDataResult<DiseaseCategoryGetDto>(diseaseCategoryDto);
    }
}