using DrDoc.Common.Entities.Abstracts;
using DrDoc.Common.Utilities.Enums;

namespace DrDoc.Common.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T> where T : class, IDto
    {
        public ErrorDataResult(T data, Messages messageId) : base(data, false, messageId)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(Messages messageId) : base(default, false, messageId)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
