using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserDisease;

public class UserDiseaseGetDto : IDto
{
    public int DiseaseId { get; set; }
    public string DiseaseTitle { get; set; }
    public int DiseaseCategoryId { get; set; }
    public string DiseaseCategoryTitle { get; set; }
}