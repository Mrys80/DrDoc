using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserFoodAllergy;

public class DeleteFoodAllergy:IDto
{
    public int UserId { get; set; }
    public int FoodId { get; set; }
}