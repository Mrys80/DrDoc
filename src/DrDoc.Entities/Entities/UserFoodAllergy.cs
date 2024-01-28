using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class UserFoodAllergy : BaseEntity
{
    public int UserId { get; set; }
    public int FoodId { get; set; }
}