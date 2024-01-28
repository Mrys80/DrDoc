using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto.Session;

namespace DrDoc.Services.Abstracts;

public interface ISessionService
{
    Task<IDataResult<SessionDto>> Get(Guid id, CancellationToken cancellationToken);
    Task<IDataResult<SessionDto>> Add(SessionAddDto sessionAddDto, CancellationToken cancellationToken);
}