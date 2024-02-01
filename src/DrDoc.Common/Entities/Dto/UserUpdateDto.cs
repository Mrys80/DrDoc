using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Common.Entities.Dto;

public class UserUpdateDto:IDto
{
    public int userId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? BirthDate { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }

}