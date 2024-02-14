namespace DrDoc.Common.Entities.Entities;

public class User : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? BirthDate { get; set; }

    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
    public string? Salt { get; set; }
    public int? RoleId { get; set; }
}