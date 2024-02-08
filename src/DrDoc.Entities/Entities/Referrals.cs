using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class Referrals : BaseEntity
{
    public int UserId { get; set; }
    public int DiseaseId { get; set; }
    public string Description { get; set; }
    public string? BP { get; set; }
    public string? HR { get; set; }
    public string? RR { get; set; }
    public string? SPO2 { get; set; }
    public string? Temp { get; set; }
    public string? Glucose { get; set; }
}