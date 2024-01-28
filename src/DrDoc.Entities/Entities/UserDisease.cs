using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class UserDisease:BaseEntity
{
    public int UserId { get; set; }
    public int DiseaseId { get; set; } 
}