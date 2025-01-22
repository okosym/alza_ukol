using Microsoft.AspNetCore.Mvc.Testing;

namespace AlzaUkol.Api.Tests;

public class TestsSetup
{
    public static HttpClient Client { get; private set; }

    static TestsSetup()
    {
        var factory = new WebApplicationFactory<Program>();
        
        Client = factory.CreateClient();

        // important, release disposables
        AppDomain.CurrentDomain.ProcessExit += (sender, args) => factory.Dispose();
    }

}
