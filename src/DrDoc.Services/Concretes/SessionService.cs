using DrDoc.Common.Abstracts;
using DrDoc.Common.Utilities.Enums;
using DrDoc.Common.Utilities.Results;
using DrDoc.Common.Utilities.Settings;
using DrDoc.Data.Abstracts;
using DrDoc.Entities.Dto.Session;
using DrDoc.Entities.Entities;
using DrDoc.Services.Abstracts;
using Mapster;
using Microsoft.Extensions.Options;

namespace DrDoc.Services.Concretes;

public class SessionService : ISessionService, IScopedDependency
{
    private readonly IRepository<Session> _sessionRepository;
    private readonly JwtSetting _jwtSetting;

    public SessionService(IRepository<Session> sessionRepository, IOptionsSnapshot<Setting> setting)
    {
        _sessionRepository = sessionRepository;
        _jwtSetting = setting.Value.JwtSetting;
    }

    public async Task<IDataResult<SessionDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        var session = await _sessionRepository.GetAsync(s => s.Id == id, cancellationToken);

        if (session is null)
        {
            return new ErrorDataResult<SessionDto>(Messages.SessionNotFound);
        }

        var sessionDto = session.Adapt<SessionDto>();

        return new SuccessDataResult<SessionDto>(sessionDto);
    }

    public async Task<IDataResult<SessionDto>> Add(SessionAddDto sessionAddDto, CancellationToken cancellationToken)
    {
        var session = new Session
        {
            IsDeleted = false,
            RegUserId = sessionAddDto.RegUserId,
            FromDate = DateTime.Now,
            ToDate = DateTime.Now.AddMinutes(_jwtSetting.ExpirationMinutes),
            RegDate = DateTime.Now
        };

        await _sessionRepository.AddAsync(session, cancellationToken);

        return await Get(session.Id, cancellationToken);
    }
}