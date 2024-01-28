using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class DiseaseCategory:BaseEntity
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
}