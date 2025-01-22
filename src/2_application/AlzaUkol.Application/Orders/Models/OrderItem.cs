namespace AlzaUkol.Application.Orders.Models;

public class OrderItem
{
    #region Properties

    public int Id { get; set; }
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public decimal PricePerItem { get; set; }
    public int Count { get; set; }

    #endregion Properties
}
