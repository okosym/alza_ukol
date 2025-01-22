namespace AlzaUkol.Application._Shared.Validation;

public interface IValidatable
{
    public void Validate(string? prefix = null);
}
