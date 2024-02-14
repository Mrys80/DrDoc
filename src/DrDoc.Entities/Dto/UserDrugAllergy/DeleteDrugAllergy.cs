using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.UserDrugAllergy;

public class DeleteDrugAllergy:IDto
{
    public int UserId { get; set; }
    public int DrugId { get; set; }
}