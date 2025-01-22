using AlzaUkol.Api.Extras.EnvelopeClasses;
using AlzaUkol.Application._Shared.Error;
using Microsoft.AspNetCore.Mvc;

namespace AlzaUkol.Api.Extras;

public static class MyValidationResponse
{
    public static void TransformValidationResponse(IServiceCollection services)
    {
        // https://www.strathweb.com/2018/02/exploring-the-apicontrollerattribute-and-its-features-for-asp-net-core-mvc-2-1/
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                List<string> errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e =>
                    {
                        string msg = e.Value.Errors.Select(x => x.ErrorMessage).Aggregate((a, b) => $"{a} {b}");
                        return $"{e.Key} | {msg}";
                    })
                    .ToList();

                // !!! HACK - filter and modify error messages
                errors = errors
                    .Where(e => !e.StartsWith("inputDTO")) // 1) Remove errors starting with "inputDTO"
                    .Select(e => { // 2) Remove sentences mentioning "line" and "position" of the error
                        var sentences = e.Split(". ") // split the error message into sentences
                            .Where(sentence => !(sentence.Contains("Path") && sentence.Contains("line") && sentence.Contains("position"))) // filter out specific sentences
                            .Select(sentence => sentence.Trim()); // Trim whitespace
                        // join sentences to msg
                        var msg = string.Join(". ", sentences);
                        // ensure the message ends with a period
                        return msg.EndsWith('.') ? msg : $"{msg}.";
                    }).ToList();

                var envelope = new Envelope<object>(ErrorEx.ValidationError(errors));

                return new OkObjectResult(envelope);
            };
        });
    }
}
