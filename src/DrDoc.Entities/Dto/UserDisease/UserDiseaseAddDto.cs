using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserDisease;

public class UserDiseaseAddDto:IDto
{
    public int UserId { get; set; }
    public List<int> DiseasesId { get; set; } 
}