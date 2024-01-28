using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.FoodCategory;

public class FoodCategoryAddDto:IDto
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
}