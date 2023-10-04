namespace RentCar.Domain.Entities;

public class CreditCard : BaseEntity
{
    private string _number = string.Empty;

    public required string Number
    {
        get { return _number; }
        set
        {
            string digitsOnly = new(value.Where(char.IsDigit).ToArray());

            _number = digitsOnly.Length == 16
                ? digitsOnly[..4] + "-" + digitsOnly[4..8] + "-" + digitsOnly[8..]
                : throw new ArgumentException("Input string must have 11 digits.");
        }
    }

    public required Name HolderName { get; set; }

    public required DateTime ExpirationDate { get; set; }

    public required string Cvv { get; set; }
}
