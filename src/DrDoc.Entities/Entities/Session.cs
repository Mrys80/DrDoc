using DrDoc.Common.Entities.Entities;

namespace DrDoc.Entities.Entities;

public class Session : BaseEntity<Guid>
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}