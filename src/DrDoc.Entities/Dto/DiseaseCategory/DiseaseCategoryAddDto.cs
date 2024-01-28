using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.DiseaseCategory;

public class DiseaseCategoryAddDto:IDto
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
}