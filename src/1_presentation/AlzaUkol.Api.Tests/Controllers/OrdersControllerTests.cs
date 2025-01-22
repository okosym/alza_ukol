using NUnit.Framework;

namespace AlzaUkol.Api.Tests.Controllers;

[TestFixture]
public class OrdersControllerTests
{
    [Test]
    public async Task T01_CreateOrder_Ok()
    {
        // Arrange
        StringContent jsonBody = TestJsonUtils.GetJsonBody(@"_TestData\Orders\OrdersIN.json");

        // Act
        HttpResponseMessage response = await TestsSetup.Client.PostAsync("api/orders/create", jsonBody);

        // Assert
        string json = AssertUtils.Json(response);
        int orderId = AssertUtils.Success(response).data;
        Assert.That(orderId > 0);
    }

    [Test]
    public async Task T02_ListOrders_Ok()
    {
        // Arrange

        // Act
        HttpResponseMessage response = await TestsSetup.Client.GetAsync("api/orders/list");

        // Assert
        string json = AssertUtils.Json(response);
        AssertUtils.Success(response);
    }

    [Test]
    public async Task T03_UpdatePaymentInfo_Ok()
    {
        // Arrange
        StringContent jsonBody = TestJsonUtils.GetJsonBody(@"_TestData\Orders\OrderPaymentInfoIN.json");

        // Act
        HttpResponseMessage response = await TestsSetup.Client.PostAsync("api/orders/UpdatePaymentInfo", jsonBody);

        // Assert
        string json = AssertUtils.Json(response);
        AssertUtils.Success(response);
    }
}
