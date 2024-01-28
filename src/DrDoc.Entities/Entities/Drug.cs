using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class Drug : BaseEntity
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
    public int DrugCategoryId { get; set; }
}