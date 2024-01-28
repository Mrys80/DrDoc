using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Entities.Dto.Session;


public class SessionAddDto : IDto
{
    public int RegUserId { get; set; }
}