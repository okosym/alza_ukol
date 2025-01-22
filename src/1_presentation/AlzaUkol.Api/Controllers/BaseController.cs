using AlzaUkol.Api.Extras.EnvelopeClasses;
using Microsoft.AspNetCore.Mvc;

namespace AlzaUkol.Api.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult Envelope<T>(T data)
    {
        Envelope<T> envelope = new Envelope<T>(data);
        return base.Ok(envelope);
    }

    protected IActionResult Envelope()
    {
        Envelope<object> envelope = new Envelope<object>();
        return base.Ok(envelope);
    }
}
