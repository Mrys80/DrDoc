using DrDoc.Common.Entities.Abstracts;
using DrDoc.Common.Entities.Dto;

namespace DrDoc.Entities.Dto.Auth;

public class 
LoginResultDto : IDto
{
    public int UserId { get; set; }
    public string Token { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public List<RoleDto> roles { get; set; }
}