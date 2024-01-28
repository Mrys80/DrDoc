using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto;

public class BaseGetDto:IDto
{
    public int Offset { get; set; }
    public int Limit { get; set; }
}