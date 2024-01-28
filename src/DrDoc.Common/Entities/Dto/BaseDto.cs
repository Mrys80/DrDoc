using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Common.Entities.Dto;

public abstract class BaseDto<TKey> : IDto
{
    public TKey Id { get; set; }
}

public abstract class BaseDto : BaseDto<int>
{
}