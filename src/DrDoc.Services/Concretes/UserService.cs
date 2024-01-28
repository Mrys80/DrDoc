using DrDoc.Common.Abstracts;
using DrDoc.Common.Entities.Dto;
using DrDoc.Common.Entities.Entities;
using DrDoc.Common.Utilities.Enums;
using DrDoc.Common.Utilities.Results;
using DrDoc.Data.Abstracts;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.UserDisease;
using DrDoc.Entities.Dto.UserDrugAllergy;
using DrDoc.Entities.Dto.UserFoodAllergy;
using DrDoc.Entities.Entities;
using DrDoc.Entities.Enum;
using DrDoc.Services.Abstracts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DrDoc.Services.Concretes;

public class UserService : IUserService, IScopedDependency
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<UserDrugAllergy> _userDrugAllergyRepository;
    private readonly IRepository<UserFoodAllergy> _userFoodAllergyRepository;
    private readonly IRepository<UserDisease> _userDiseaseRepository;
    private readonly IRepository<DiseaseCategory> _diseaseCategoryRepository;
    private readonly IRepository<FoodCategory> _foodCategoryRepository;
    private readonly IRepository<DrugCategory> _drugCategoryRepository;
    private readonly IRepository<Disease> _diseaseRepository;
    private readonly IRepository<Food> _foodRepository;
    private readonly IRepository<Drug> _drugRepository;


    public UserService(IRepository<User> userRepository, IRepository<UserDrugAllergy> userDrugAllergyRepository,
        IRepository<UserFoodAllergy> userFoodAllergyRepository, IRepository<UserDisease> userDiseaseRepository,
        IRepository<DiseaseCategory> diseaseCategoryRepository, IRepository<FoodCategory> foodCategoryRepository,
        IRepository<DrugCategory> drugCategoryRepository, IRepository<Disease> diseaseRepository,
        IRepository<Food> foodRepository, IRepository<Drug> drugRepository)
    {
        _userRepository = userRepository;
        _userDrugAllergyRepository = userDrugAllergyRepository;
        _userFoodAllergyRepository = userFoodAllergyRepository;
        _userDiseaseRepository = userDiseaseRepository;
        _diseaseCategoryRepository = diseaseCategoryRepository;
        _foodCategoryRepository = foodCategoryRepository;
        _drugCategoryRepository = drugCategoryRepository;
        _diseaseRepository = diseaseRepository;
        _foodRepository = foodRepository;
        _drugRepository = drugRepository;
    }

    public async Task<IDataResult<UserDto>> AddUser(CurrentUserDto currentUser, UserAddDto userAddDto,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.TableNoTracking.FirstOrDefaultAsync(user =>
            user.NationalCode == userAddDto.NationalCode, cancellationToken: cancellationToken);

        if (user is not null)
            return new ErrorDataResult<UserDto>(Messages.UserRepeated);

        user = new User
        {
            PhoneNumber = userAddDto.PhoneNumber,
            FirstName = userAddDto.FirstName,
            LastName = userAddDto.LastName,
            NationalCode = userAddDto.NationalCode,
            BirthDate = userAddDto.BirthDate,
            Gender = userAddDto.Gender,
            Address = userAddDto.Address,
            RoleId = (int)Roles.User,
            RegDate = DateTime.Now,
            RegUserId = currentUser.UserId,
            IsDeleted = false
        };

        await _userRepository.AddAsync(user, cancellationToken);


        var userDto = user.Adapt<UserDto>();
        return new SuccessDataResult<UserDto>(userDto);
    }

    public async Task<IResult> AddUserDrugAllergy(CurrentUserDto currentUser,
        UserDrugAllergyAddDto userDrugAllergyAddDto,
        CancellationToken cancellationToken)
    {
        foreach (var drugId in userDrugAllergyAddDto.DrugsId)
        {
            await _userDrugAllergyRepository.AddAsync(new UserDrugAllergy
            {
                UserId = userDrugAllergyAddDto.UserId,
                DrugId = drugId,
                RegUserId = currentUser.UserId,
                RegDate = DateTime.Now,
                IsDeleted = false
            }, cancellationToken);
        }

        return new SuccessResult(Messages.SuccessfullyDone);
    }

    public async Task<IResult> AddUserFoodAllergy(
        CurrentUserDto currentUser,
        UserFoodAllergyAddDto userFoodAllergyAddDto,
        CancellationToken cancellationToken)
    {
        foreach (var foodId in userFoodAllergyAddDto.FoodsId)
        {
            await _userFoodAllergyRepository.AddAsync(new UserFoodAllergy
            {
                UserId = userFoodAllergyAddDto.UserId,
                FoodId = foodId,
                RegUserId = currentUser.UserId,
                RegDate = DateTime.Now,
                IsDeleted = false
            }, cancellationToken);
        }

        return new SuccessResult(Messages.SuccessfullyDone);
    }

    public async Task<IResult> AddUserDisease(
        CurrentUserDto currentUser,
        UserDiseaseAddDto userDiseaseAddDto,
        CancellationToken cancellationToken)
    {
        foreach (var foodId in userDiseaseAddDto.DiseasesId)
        {
            await _userDiseaseRepository.AddAsync(new UserDisease
            {
                UserId = userDiseaseAddDto.UserId,
                DiseaseId = foodId,
                RegUserId = currentUser.UserId,
                RegDate = DateTime.Now,
                IsDeleted = false
            }, cancellationToken);
        }

        return new SuccessResult(Messages.SuccessfullyDone);
    }

    public async Task<IListResult<List<UserDrugAllergyGetDto>>> GetUserDrugAllergy(int userId,
        CancellationToken cancellationToken)
    {
        var userDrugs = await (
            from userDrug in _userDrugAllergyRepository.TableNoTracking
            join user in _userRepository.TableNoTracking on userDrug.UserId equals user.Id
            join drug in _drugRepository.TableNoTracking on userDrug.DrugId equals drug.Id
            join drugCategory in _drugCategoryRepository.TableNoTracking on drug.DrugCategoryId equals drugCategory.Id
            where
                userDrug.IsDeleted == false &&
                user.IsDeleted == false &&
                user.Id == userId &&
                drug.IsDeleted == false &&
                drugCategory.IsDeleted == false
            select new UserDrugAllergyGetDto
            {
                DrugId = drug.Id,
                DrugTitle = drug.Title,
                DrugCategoryId = drugCategory.Id,
                DrugCategoryTitle = drugCategory.Title
            }
        ).ToListAsync(cancellationToken);

        return new SuccessListResult<List<UserDrugAllergyGetDto>>(userDrugs);
    }

    public async Task<IListResult<List<UserFoodAllergyGetDto>>> GetUserFoodAllergy(int userId,
        CancellationToken cancellationToken)
    {
        var userFoods = await (
            from userFood in _userFoodAllergyRepository.TableNoTracking
            join user in _userRepository.TableNoTracking on userFood.UserId equals user.Id
            join food in _foodRepository.TableNoTracking on userFood.FoodId equals food.Id
            join foodCategory in _foodCategoryRepository.TableNoTracking on food.FoodCategoryId equals foodCategory.Id
            where
                userFood.IsDeleted == false &&
                user.IsDeleted == false &&
                user.Id == userId &&
                food.IsDeleted == false &&
                foodCategory.IsDeleted == false
            select new UserFoodAllergyGetDto
            {
                FoodId = food.Id,
                FoodTitle = food.Title,
                FoodCategoryId = foodCategory.Id,
                FoodCategoryTitle = foodCategory.Title
            }
        ).ToListAsync(cancellationToken);

        return new SuccessListResult<List<UserFoodAllergyGetDto>>(userFoods);
    }

    public async Task<IListResult<List<UserDiseaseGetDto>>> GetUserDisease(int userId,
        CancellationToken cancellationToken)
    {
        var userDiseases = await (
            from userDisease in _userDiseaseRepository.TableNoTracking
            join user in _userRepository.TableNoTracking on userDisease.UserId equals user.Id
            join disease in _diseaseRepository.TableNoTracking on userDisease.DiseaseId equals disease.Id
            join diseaseCategory in _diseaseCategoryRepository.TableNoTracking on disease.DiseaseCategoryId equals
                diseaseCategory.Id
            where
                userDisease.IsDeleted == false &&
                user.IsDeleted == false &&
                user.Id == userId &&
                disease.IsDeleted == false &&
                diseaseCategory.IsDeleted == false
            select new UserDiseaseGetDto
            {
                DiseaseId = disease.Id,
                DiseaseTitle = disease.Title,
                DiseaseCategoryId = diseaseCategory.Id,
                DiseaseCategoryTitle = diseaseCategory.Title
            }
        ).ToListAsync(cancellationToken);

        return new SuccessListResult<List<UserDiseaseGetDto>>(userDiseases);
    }
}