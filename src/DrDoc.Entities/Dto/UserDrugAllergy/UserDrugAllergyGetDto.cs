using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserDrugAllergy;

public class UserDrugAllergyGetDto : IDto
{
    public int DrugId { get; set; }
    public string DrugTitle { get; set; }
    public int DrugCategoryId { get; set; }
    public string DrugCategoryTitle { get; set; }
}