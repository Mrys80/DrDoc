using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.DiseaseCategory;

public class DiseaseCategoryGetDto:IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? ImageId { get; set; }
}