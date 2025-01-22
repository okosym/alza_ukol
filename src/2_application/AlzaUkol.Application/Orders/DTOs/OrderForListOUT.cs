using AlzaUkol.Application.Orders.Models;

namespace AlzaUkol.Application.Orders.DTOs;

public class OrderForListOUT
{
    #region Properties

    public int Id { get; set; }
    public string CustomerName { get; set; }
    public OrderState State { get; set; }
    public decimal TotalPrice { get; set; }

    #endregion Properties
}
