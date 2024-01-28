using DrDoc.Common.Entities.Dto;
using DrDoc.Common.Entities.Entities;

namespace DrDoc.Common.Utilities.Security.Jwt;

public interface ITokenHelper
{
    CurrentUser CurrentUser { get; }
    AccessToken CreateToken(User user, IEnumerable<RoleDto> roles, string sessionId);
}