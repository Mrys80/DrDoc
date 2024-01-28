using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class UserDrugAllergy : BaseEntity
{
    public int UserId { get; set; }
    public int DrugId { get; set; }
}