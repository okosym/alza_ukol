using AlzaUkol.Application.Orders;
using AlzaUkol.Application.Orders.DTOs;
using AlzaUkol.Application.Orders.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlzaUkol.Api.Controllers;

[ApiController]
public class OrdersController : BaseController
{
    private readonly OrdersFacade _ordersFacade;

    public OrdersController(OrdersFacade ordersFacade)
    {
        _ordersFacade = ordersFacade;
    }

    [HttpPost]
    [Route("~/api/orders/create")]
    [ProducesResponseType(200, Type = typeof(int))]
    public async Task<IActionResult> CreateOrder(OrderIN inputDTO)
    {
        // call facade method
        int orderId = await _ordersFacade.CreateOrder(inputDTO);

        // return envelope
        return Envelope(orderId);
    }

    [HttpGet]
    [Route("~/api/orders/list")]
    [ProducesResponseType(200, Type = typeof(List<OrderForListOUT>))]
    public async Task<IActionResult> ListOrders()
    {
        // call facade method
        List<OrderForListOUT> list = await _ordersFacade.ListOrders();

        // return envelope
        return Envelope(list);
    }

    [HttpPost]
    [Route("~/api/orders/UpdatePaymentInfo")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdatePaymentInfo(OrderPaymentInfoIN inputDTO)
    {
        // call facade method
        await _ordersFacade.UpdateOrderPaymentInfo(inputDTO);

        // return envelope
        return Envelope();
    }
}
