using DrDoc.Common.Abstracts;
using DrDoc.Common.Entities.Dto;
using DrDoc.Common.Entities.Entities;
using DrDoc.Common.Utilities.Enums;
using DrDoc.Common.Utilities.Results;
using DrDoc.Common.Utilities.Security.Hashing;
using DrDoc.Common.Utilities.Security.Jwt;
using DrDoc.Data.Abstracts;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Auth;
using DrDoc.Entities.Dto.Session;
using DrDoc.Entities.Entities;
using DrDoc.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DrDoc.Services.Concretes;

public class AuthService : IAuthService, IScopedDependency
{
    private readonly IRepository<User> _userRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly ISessionService _sessionService;
    private readonly IRepository<Session> _sessionRepository;
    private readonly IRepository<Role> _roleRepository;


    public AuthService(IRepository<User> userRepository, ITokenHelper tokenHelper,
        ISessionService sessionService, IRepository<Session> sessionRepository, IRepository<Role> roleRepository)
    {
        _userRepository = userRepository;
        _tokenHelper = tokenHelper;
        _sessionService = sessionService;
        _sessionRepository = sessionRepository;
        _roleRepository = roleRepository;
    }

    public async Task<IDataResult<LoginResultDto>> Login(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(
            user => user.PhoneNumber == loginDto.Username && user.IsDeleted == false,
            cancellationToken);

        if (user is null)
        {
            return new ErrorDataResult<LoginResultDto>(Messages.UsernameOrPasswordIncorrect);
        }


        if (HashingHelper.VerifyPasswordHash(loginDto.Password, user.Password, user.Salt) is false)
        {
            return new ErrorDataResult<LoginResultDto>(Messages.UsernameOrPasswordIncorrect);
        }

        var userRoles = await _roleRepository.TableNoTracking.Where(
                role =>
                    role.Id == user.RoleId &&
                    role.IsDeleted == false)
            .Select(role => new RoleDto
            {
                Id = role.Id,
                Title = role.Title
            })
            .ToListAsync(cancellationToken);


        var sessionAddDto = new SessionAddDto
        {
            RegUserId = user.Id
        };
        var session = await _sessionService.Add(sessionAddDto, cancellationToken);

        if (session.IsSuccess is false)
        {
            return new ErrorDataResult<LoginResultDto>(Messages.ServerError);
        }

        var accessToken = _tokenHelper.CreateToken(user, userRoles, session.Data.Id.ToString());

        var loginResultDto = new LoginResultDto
        {
            UserId = user.Id,
            Token = accessToken.Token,
            FirstName = user.FirstName,
            LastName = user.LastName,
            NationalCode = user.NationalCode,
            roles = userRoles
        };

        return new SuccessDataResult<LoginResultDto>(loginResultDto);
    }


    public async Task<IResult> Logout(CurrentUserDto currentUser, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x =>
            x.Id == currentUser.UserId && x.IsDeleted == false, cancellationToken);

        if (user == null)
        {
            return new ErrorResult(Messages.UserNotFound);
        }

        var session =
            await _sessionRepository.GetAsync(x => x.Id == Guid.Parse(currentUser.SessionId), cancellationToken);

        if (session != null)
        {
            session.IsDeleted = true;
            await _sessionRepository.UpdateAsync(session, cancellationToken);
        }

        return new SuccessResult();
    }
}