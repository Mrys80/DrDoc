using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserFoodAllergy;

public class UserFoodAllergyAddDto:IDto
{
    public int UserId { get; set; }
    public List<int> FoodsId { get; set; } 
}