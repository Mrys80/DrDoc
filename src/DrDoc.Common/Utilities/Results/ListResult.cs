using DrDoc.Common.Entities.Abstracts;
using DrDoc.Common.Utilities.Enums;

namespace DrDoc.Common.Utilities.Results
{
    public class ListResult<T> : Result, IListResult<T> where T : class, IEnumerable<IDto>
    {
        public T Data { get; }

        public ListResult(T data, bool isSuccess, Messages messageId) : base(isSuccess, messageId)
        {
            Data = data;
        }

        public ListResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }
    }
}
