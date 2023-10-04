namespace RentCar.Domain.ValueObjects;

public class Identification : ValueObject
{
    private string _id = string.Empty;

    public required string Id
    {
        get { return _id; }
        set
        {
            string digitsOnly = new(value.Where(char.IsDigit).ToArray());

            _id = digitsOnly.Length == 11
                ? digitsOnly[..3] + "-" + digitsOnly[3..^1] + "-" + digitsOnly[^1]
                : throw new ArgumentException("Input string must have 11 digits.");
        }
    }

    public override string ToString()
    {
        return Id;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
