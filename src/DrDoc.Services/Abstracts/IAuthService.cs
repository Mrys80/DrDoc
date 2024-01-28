using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Auth;

namespace DrDoc.Services.Abstracts;

public interface IAuthService
{
    Task<IDataResult<LoginResultDto>> Login(LoginDto loginDto, CancellationToken cancellationToken);

    Task<IResult> Logout(CurrentUserDto currentUser, CancellationToken cancellationToken);
}