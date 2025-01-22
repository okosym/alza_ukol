using System.Runtime.InteropServices.JavaScript;
using AlzaUkol.Application._Shared.Error;
using AlzaUkol.Application.Orders.DTOs;

namespace AlzaUkol.Application.Orders.Models;

public class Order
{
    #region Properties

    public int Id { get; set; }
    public string CustomerName { get; set; }
    public OrderState State { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ChangeDate { get; set; }
    public List<OrderItem> Items { get; set; }

    #endregion Properties

    public static Order Create(OrderIN inputDTO)
    {
        DateTime now = DateTime.UtcNow;
        
        Order o = new Order
        {
            CustomerName = inputDTO.CustomerName,
            State = OrderState.New,
            CreateDate = now,
            ChangeDate = now,
            Items = inputDTO.OrderItems.Select(x => new OrderItem
            {
                ProductName = x.ProductName,
                PricePerItem = x.PricePerItem,
                Count = x.Count
            }).ToList()
        };

        return o;
    }

    public void UpdatePaymentInfo(bool paid)
    {
        // not sure about this, but it seems like a good idea to check the state of the order...

        if (this.State == OrderState.Paid)
            throw ErrorEx.ApplicationError("The order has already been paid.");

        if (this.State == OrderState.Cancelled)
            throw ErrorEx.ApplicationError("The order has already been cancelled.");
        
        if (this.State == OrderState.New)
            this.State = paid ? OrderState.Paid : OrderState.Cancelled;
        else
            throw ErrorEx.ApplicationError("The order is not in any of the valid states (New | Paid | Cancelled).");
    }
}
