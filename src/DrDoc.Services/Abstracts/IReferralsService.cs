using DrDoc.Common.Utilities.Results;
using DrDoc.Entities.Dto;
using DrDoc.Entities.Dto.Drug;
using DrDoc.Entities.Dto.Referrals;

namespace DrDoc.Services.Abstracts;

public interface IReferralsService
{
    Task<IListResult<List<ReferralsGetDto>>> GetReferralsByUserId(
        CurrentUserDto currentUser,
        int userId, CancellationToken cancellationToken);


    Task<IListResult<List<ReferralsGetDto>>> GetReferralsByPeriod(
        CurrentUserDto currentUser,
        DatePeriod datePeriod, CancellationToken cancellationToken);


    Task<IDataResult<ReferralsGetDto>> SubmitReferrals(
        CurrentUserDto currentUser,
        ReferralsAddDto referralsAddDto,
        CancellationToken cancellationToken);
}