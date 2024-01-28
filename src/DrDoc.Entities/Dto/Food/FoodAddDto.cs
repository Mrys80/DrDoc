using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.Food;

public class FoodAddDto:IDto
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
    public int FoodCategoryId { get; set; }
}