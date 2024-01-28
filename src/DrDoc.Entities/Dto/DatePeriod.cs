using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto;

public class DatePeriod:IDto
{
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
}