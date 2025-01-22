namespace AlzaUkol.Application._Shared.Error;

public class ErrorEx : Exception
{
    #region Properties

    public ErrorType ErrorType { get; set; }
    public List<string> ErrorMessages { get; set; }

    #endregion Properties

    private ErrorEx(ErrorType errorType, List<string> errorMessages)
    {
        ErrorType = errorType;
        ErrorMessages = errorMessages;
    }
    private ErrorEx(ErrorType errorType, string errorMessage)
    {
        ErrorType = errorType;
        ErrorMessages = [errorMessage];
    }

    public static ErrorEx ValidationError(string errorMessage) => new ErrorEx(ErrorType.ValidationError, errorMessage);
    public static ErrorEx ValidationError(List<string> errorMessages) => new ErrorEx(ErrorType.ValidationError, errorMessages);

    public static ErrorEx AuthError(string errorMessage) => new ErrorEx(ErrorType.AuthError, errorMessage);
    public static ErrorEx AuthError(List<string> errorMessages) => new ErrorEx(ErrorType.AuthError, errorMessages);

    public static ErrorEx ApplicationError(string errorMessage) => new ErrorEx(ErrorType.ApplicationError, errorMessage);
    public static ErrorEx ApplicationError(List<string> errorMessages) => new ErrorEx(ErrorType.ApplicationError, errorMessages);
}
