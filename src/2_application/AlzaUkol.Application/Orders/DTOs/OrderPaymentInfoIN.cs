using Newtonsoft.Json;

namespace AlzaUkol.Application.Orders.DTOs;

public class OrderPaymentInfoIN
{
    #region Properties

    [JsonRequired]
    public int OrderId { get; set; }
    [JsonRequired]
    public bool Paid { get; set; }

    #endregion Properties
}
