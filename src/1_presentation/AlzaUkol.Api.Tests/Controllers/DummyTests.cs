using NUnit.Framework;

namespace AlzaUkol.Api.Tests.Controllers;

[TestFixture]
public class DummyTests
{
    [Test]
    public async Task T01_GetMessage_Ok()
    {
        // Arrange
        // Act
        HttpResponseMessage response = await TestsSetup.Client.GetAsync("api/dummy/message");

        // Assert
        string json = AssertUtils.Json(response);
        dynamic d = AssertUtils.Success(response);
        Assert.That(d.data.message == "Hello Buddy");
    }

    [Test]
    public async Task T02_ErrorTest()
    {
        // Arrange
        // Act
        HttpResponseMessage response = await TestsSetup.Client.GetAsync("api/dummy/error");

        // Assert
        string json = AssertUtils.Json(response);
        dynamic d = AssertUtils.Error(response);
        Assert.That(d.error.errorType == "ApplicationError");
    }
}
