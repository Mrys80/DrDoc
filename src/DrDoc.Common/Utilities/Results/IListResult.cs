using DrDoc.Common.Entities.Abstracts;

namespace DrDoc.Common.Utilities.Results
{
    public interface IListResult<out T> : IResult where T : class?, IEnumerable<IDto>?
    {
        T Data { get; }
    }
}
