using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Common.Utilities.Results
{
    public interface IDataResult<out T> : IResult where T : class, IDto
    {
        T Data { get; }
    }
}
