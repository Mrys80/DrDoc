using DrDoc.Common.Utilities.Enums;

namespace DrDoc.Common.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(Messages messageId) : base(true, messageId)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
