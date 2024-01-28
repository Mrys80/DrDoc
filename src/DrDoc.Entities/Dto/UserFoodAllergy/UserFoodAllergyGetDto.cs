using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserFoodAllergy;

public class UserFoodAllergyGetDto : IDto
{
    public int FoodId { get; set; }
    public string FoodTitle { get; set; }
    public int FoodCategoryId { get; set; }
    public string FoodCategoryTitle { get; set; }
}