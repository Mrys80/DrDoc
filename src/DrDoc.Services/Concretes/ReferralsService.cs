using DrDoc.Common.Abstracts;
using DrDoc.Common.Entities.Dto;
using DrDoc.Common.Entities.Entities;
using DrDoc.Common.Utilities.Enums;
using DrDoc.Common.Utilities.Results;
using DrDoc.Data.Abstracts;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Disease;
using DrDoc.Entities.Dto.DiseaseCategory;
using DrDoc.Entities.Dto.Referrals;
using DrDoc.Entities.Entities;
using DrDoc.Services.Abstracts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DrDoc.Services.Concretes;

public class ReferralsService : IReferralsService, IScopedDependency
{
    private readonly IRepository<Referrals> _referralsRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Disease> _diseaseRepository;
    private readonly IRepository<DiseaseCategory> _diseaseCategoryRepository;

    public ReferralsService(IRepository<Referrals> referralsRepository, IRepository<User> userRepository,
        IRepository<Disease> diseaseRepository, IRepository<DiseaseCategory> diseaseCategoryRepository)
    {
        _referralsRepository = referralsRepository;
        _userRepository = userRepository;
        _diseaseRepository = diseaseRepository;
        _diseaseCategoryRepository = diseaseCategoryRepository;
    }


    public async Task<IListResult<List<ReferralsGetDto>>> GetReferralsByUserId(
        CurrentUserDto currentUser,
        int userId,
        CancellationToken cancellationToken)
    {
        var r = await (
            from reff in _referralsRepository.TableNoTracking
            join user in _userRepository.TableNoTracking on reff.UserId equals user.Id
            join disease in _diseaseRepository.TableNoTracking on reff.DiseaseId equals disease.Id
            join diseaseCategory in _diseaseCategoryRepository.TableNoTracking on disease.DiseaseCategoryId equals
                diseaseCategory.Id
            where
                user.Id == userId &&
                user.RoleId == 3 &&
                user.IsDeleted == false &&
                reff.IsDeleted == false &&
                reff.RegUserId == currentUser.UserId &&
                disease.IsDeleted == false &&
                diseaseCategory.IsDeleted == false
            select new ReferralsGetDto
            {
                Id = user.Id,
                User = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    NationalCode = user.NationalCode,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    Address = user.Address,
                    BirthDate = user.BirthDate
                },
                Disease = new DiseaseGetDto
                {
                    Id = disease.Id,
                    Title = disease.Title,
                    ImageId = disease.ImageId
                },
                DiseaseCategory = new DiseaseCategoryGetDto
                {
                    Id = diseaseCategory.Id,
                    Title = diseaseCategory.Title,
                    ImageId = diseaseCategory.ImageId
                },
                Description = reff.Description,
                HR = reff.HR,
                RR = reff.RR,
                SPO2 = reff.SPO2,
                Temp = reff.Temp,
                Glucose = reff.Glucose
            }
        ).ToListAsync(cancellationToken);
        return new SuccessListResult<List<ReferralsGetDto>>(r);
    }

    public async Task<IListResult<List<ReferralsGetDto>>> GetReferralsByPeriod(
        CurrentUserDto currentUser,
        DatePeriod datePeriod,
        CancellationToken cancellationToken)
    {
        var r = await (
            from reff in _referralsRepository.TableNoTracking
            join user in _userRepository.TableNoTracking on reff.UserId equals user.Id
            join disease in _diseaseRepository.TableNoTracking on reff.DiseaseId equals disease.Id
            join diseaseCategory in _diseaseCategoryRepository.TableNoTracking on disease.DiseaseCategoryId equals
                diseaseCategory.Id
            where
                reff.RegDate <= datePeriod.startDate &&
                reff.RegDate >= datePeriod.endDate &&
                user.RoleId == 3 &&
                user.IsDeleted == false &&
                reff.RegUserId == currentUser.UserId &&
                reff.IsDeleted == false &&
                disease.IsDeleted == false &&
                diseaseCategory.IsDeleted == false
            select new ReferralsGetDto
            {
                Id = user.Id,
                User = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    NationalCode = user.NationalCode,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    Address = user.Address,
                    BirthDate = user.BirthDate
                },
                Disease = new DiseaseGetDto
                {
                    Id = disease.Id,
                    Title = disease.Title,
                    ImageId = disease.ImageId
                },
                DiseaseCategory = new DiseaseCategoryGetDto
                {
                    Id = diseaseCategory.Id,
                    Title = diseaseCategory.Title,
                    ImageId = diseaseCategory.ImageId
                },
                Description = reff.Description,
                HR = reff.HR,
                RR = reff.RR,
                SPO2 = reff.SPO2,
                Temp = reff.Temp,
                Glucose = reff.Glucose
            }
        ).ToListAsync(cancellationToken);

        return new SuccessListResult<List<ReferralsGetDto>>(r);
    }

    public async Task<IDataResult<ReferralsGetDto>> SubmitReferrals(
        CurrentUserDto currentUser,
        ReferralsAddDto referralsAddDto,
        CancellationToken cancellationToken)
    {
        var referrals = new Referrals
        {
            UserId = referralsAddDto.UserId,
            DiseaseId = referralsAddDto.DiseaseId,
            Description = referralsAddDto.Description,
            HR = referralsAddDto.HR,
            RR = referralsAddDto.RR,
            SPO2 = referralsAddDto.SPO2,
            Temp = referralsAddDto.Temp,
            Glucose = referralsAddDto.Glucose,
            RegUserId = currentUser.UserId,
            RegDate = DateTime.Now,
            IsDeleted = false
        };

        await _referralsRepository.AddAsync(referrals, cancellationToken);
        

        return new SuccessDataResult<ReferralsGetDto>(Messages.SuccessfullyDone);

    }
}