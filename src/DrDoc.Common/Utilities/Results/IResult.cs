using DrDoc.Common.Utilities.Enums;

namespace DrDoc.Common.Utilities.Results
{
    public interface IResult
    {
        bool IsSuccess { get; }

        //[JsonIgnore]
        Messages MessageId { get; }

        //[JsonIgnore]
        string MessageEn { get; }
        string Message { get; }
    }
}
