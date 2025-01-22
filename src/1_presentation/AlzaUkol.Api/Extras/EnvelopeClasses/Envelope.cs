using AlzaUkol.Application._Shared.Error;

namespace AlzaUkol.Api.Extras.EnvelopeClasses;

public class Envelope<T>
{
    #region Properties

    public bool Success { get; set; }
    public T? Data { get; set; }
    public EnvelopeError? Error { get; set; }

    #endregion Properties

    public Envelope()
    {
        this.Success = true;
    }

    public Envelope(T data)
    {
        this.Success = true;
        this.Data = data;
    }

    public Envelope(ErrorEx errorEx)
    {
        this.Success = false;
        this.Error = new EnvelopeError(errorEx.ErrorType, errorEx.ErrorMessages);
    }

    public Envelope(Exception ex)
    {
        this.Success = false;
        this.Error = new EnvelopeError(ErrorType.Exception, [ex.Message]);
    }
}
