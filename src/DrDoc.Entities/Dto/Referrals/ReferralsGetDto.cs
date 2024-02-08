using DrDoc.Common.Entities.Abstracts;
using DrDoc.Common.Entities.Dto;
using DrDoc.Entities.Dto.Disease;
using DrDoc.Entities.Dto.DiseaseCategory;

namespace DrDoc.Entities.Dto.Referrals;

public class ReferralsGetDto : IDto
{
    public int Id { get; set; }
    public UserDto User { get; set; }
    public DiseaseGetDto Disease { get; set; }
    public DiseaseCategoryGetDto DiseaseCategory { get; set; }
    public string Description { get; set; }
    public string? HR { get; set; }
    public string? BP { get; set; }

    public string? RR { get; set; }
    public string? SPO2 { get; set; }
    public string? Temp { get; set; }
    public string? Glucose { get; set; }
    public DateTime? RegDate { get; set; }
}