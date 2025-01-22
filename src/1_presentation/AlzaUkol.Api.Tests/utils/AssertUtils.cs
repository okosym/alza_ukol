using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AlzaUkol.Api.Tests;

public static class AssertUtils
{
    public static dynamic Success(HttpResponseMessage response) => __ProcessResponse(response, true);
    public static dynamic Error(HttpResponseMessage response) => __ProcessResponse(response, false);

    private static dynamic __ProcessResponse(HttpResponseMessage response, bool success = true)
    {
        // assert OK status code
        Assert.That(response.StatusCode == HttpStatusCode.OK);

        // get body
        string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        // deserialize body to dynamic
        dynamic d = JsonConvert.DeserializeObject(responseBody);

        // assert success==true | success==false
        Assert.That(d.success == success);

        // return dynamic
        return d;
    }

    public static string Json(HttpResponseMessage response)
    {
        // get body
        string json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        // format json from body
        string formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented);

        // return formatted json
        return formattedJson;
    }
}
