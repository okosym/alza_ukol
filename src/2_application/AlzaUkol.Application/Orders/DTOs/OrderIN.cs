using System.ComponentModel.DataAnnotations;
using AlzaUkol.Application._Shared.Error;
using AlzaUkol.Application._Shared.Validation;

namespace AlzaUkol.Application.Orders.DTOs;

public class OrderIN : IValidatable
{
    #region Properties

    [Required]
    public string CustomerName { get; set; }
    [Required]
    public List<OrderItemIN> OrderItems { get; set; }

    #endregion Properties

    public void Validate(string? prefix = null)
    {
        if (OrderItems == null || OrderItems.Count == 0)
            throw ErrorEx.ValidationError($"{prefix}OrderItems | OrderItems are required.");

        for (int i = 0; i < OrderItems.Count; i++)
            OrderItems[i].Validate($"OrderItems[{i}].");
    }
}
