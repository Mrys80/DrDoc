using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.Referrals;

public class ReferralsAddDto : IDto
{
    public int UserId { get; set; }
    public int DiseaseId { get; set; }
    public string Description { get; set; }
    public string? HR { get; set; }
    public string? BP { get; set; }

    public string? RR { get; set; }
    public string? SPO2 { get; set; }
    public string? Temp { get; set; }
    public string? Glucose { get; set; }
}