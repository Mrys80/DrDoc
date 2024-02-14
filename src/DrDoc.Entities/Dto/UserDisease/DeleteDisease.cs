using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserDisease;

public class DeleteDisease:IDto
{
    public int UserId { get; set; }
    public int DiseaseId { get; set; }
}