using System.Diagnostics;
using DrDoc.Common.Entities.Dto;
using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Disease;
using DrDoc.Entities.Dto.Drug;
using DrDoc.Entities.Dto.Food;
using DrDoc.Entities.Dto.UserDisease;
using DrDoc.Entities.Dto.UserDrugAllergy;
using DrDoc.Entities.Dto.UserFoodAllergy;

namespace DrDoc.Services.Abstracts;

public interface IUserService
{
    Task<IDataResult<UserDto>> AddUser(
        CurrentUserDto currentUser, UserAddDto userAddDto, CancellationToken cancellationToken);


    Task<IDataResult<UserDto>> UpdateUser(
        UserUpdateDto userUpdateDto, CancellationToken cancellationToken);

    Task<IDataResult<UserDto>> GetUser(
        string nationalCode, CancellationToken cancellationToken);

    Task<IListResult<List<UserDto>>> GetAllUser(CancellationToken cancellationToken);


    Task<IResult> AddUserDrugAllergy(
        CurrentUserDto currentUser, UserDrugAllergyAddDto userDrugAllergyAddDto, CancellationToken cancellationToken);

    Task<IResult> AddUserFoodAllergy(
        CurrentUserDto currentUser, UserFoodAllergyAddDto userFoodAllergyAddDto, CancellationToken cancellationToken);

    Task<IResult> AddUserDisease(
        CurrentUserDto currentUser, UserDiseaseAddDto userDiseaseAddDto, CancellationToken cancellationToken);


    Task<IListResult<List<UserDrugAllergyGetDto>>> GetUserDrugAllergy(int userId, CancellationToken cancellationToken);

    Task<IListResult<List<UserFoodAllergyGetDto>>> GetUserFoodAllergy(int userId, CancellationToken cancellationToken);

    Task<IListResult<List<UserDiseaseGetDto>>> GetUserDisease(int userId, CancellationToken cancellationToken);


    Task<IResult> DeleteUserDrugAllergy(
        DeleteDrugAllergy deleteDrugAllergy, CancellationToken cancellationToken);

    Task<IResult> DeleteUserFoodAllergy(
        DeleteFoodAllergy deleteFoodAllergy, CancellationToken cancellationToken);

    Task<IResult> DeleteUserDisease(
        DeleteDisease deleteDisease, CancellationToken cancellationToken);
}