using AlzaUkol.Application._Shared.Error;
using AlzaUkol.Application._Shared.Validation;
using Newtonsoft.Json;

namespace AlzaUkol.Application.Orders.DTOs;

public class OrderItemIN : IValidatable
{
    #region Properties

    [JsonRequired]
    public string ProductName { get; set; }
    [JsonRequired]
    public decimal PricePerItem { get; set; }
    [JsonRequired]
    public int Count { get; set; }

    #endregion Properties

    public void Validate(string? prefix = null)
    {
        List<string> errors = new List<string>();

        if (Count <= 0)
            errors.Add($"{prefix}Count | Count must be greater than 0.");

        if (PricePerItem < 0)
            errors.Add($"{prefix}PricePerItem | PricePerItem must be greater than or equal to 0.");

        if (errors.Count > 0)
            throw ErrorEx.ValidationError(errors);
    }
}
