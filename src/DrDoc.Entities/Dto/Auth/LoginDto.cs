using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.Auth;

public class LoginDto : IDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}