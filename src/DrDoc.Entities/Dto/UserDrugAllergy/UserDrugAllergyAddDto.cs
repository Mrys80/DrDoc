using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserDrugAllergy;

public class UserDrugAllergyAddDto:IDto
{
    public int UserId { get; set; }
    public List<int> DrugsId { get; set; } 
}