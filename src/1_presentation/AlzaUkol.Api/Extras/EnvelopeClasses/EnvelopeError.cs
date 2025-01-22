using AlzaUkol.Application._Shared.Error;

namespace AlzaUkol.Api.Extras.EnvelopeClasses;

public class EnvelopeError
{
    #region Properties

    public ErrorType ErrorType { get; set; }
    public List<string> ErrorMessages { get; set; }

    #endregion Properties

    public EnvelopeError(ErrorType errorType, List<string> errorMessages)
    {
        this.ErrorType = errorType;
        this.ErrorMessages = errorMessages;
    }
}
