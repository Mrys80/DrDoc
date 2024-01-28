using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.DrugCategory;

public class DrugCategoryAddDto:IDto
{
    public string Title { get; set; }
    public string? ImageId { get; set; }
}