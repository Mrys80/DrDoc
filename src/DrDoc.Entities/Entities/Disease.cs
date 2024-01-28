using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class Disease : BaseEntity
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
    public int DiseaseCategoryId { get; set; }
}