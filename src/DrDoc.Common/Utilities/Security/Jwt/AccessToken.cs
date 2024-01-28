using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Common.Utilities.Security.Jwt;

public class AccessToken : IDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}