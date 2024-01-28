using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class FoodCategory:BaseEntity
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
}