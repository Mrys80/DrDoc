using DrDoc.Common.Utilities.Enums;

namespace DrDoc.Common.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(Messages messageId) : base(false, messageId)
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}
