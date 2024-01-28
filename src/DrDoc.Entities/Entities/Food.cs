using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class Food : BaseEntity
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
    public int FoodCategoryId { get; set; }

}