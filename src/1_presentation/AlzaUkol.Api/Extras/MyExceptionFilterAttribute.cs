using AlzaUkol.Api.Extras.EnvelopeClasses;
using AlzaUkol.Application._Shared.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlzaUkol.Api.Extras;

public class MyExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        Exception ex = context.Exception;

        Envelope<object> envelope;
        if (ex is ErrorEx)
        {
            ErrorEx errorEx = ex as ErrorEx;
            envelope = new Envelope<object>(errorEx);
        }
        else
        {
            envelope = new Envelope<object>(ex);
        }

        context.Result = new JsonResult(envelope);
    }
}
