namespace RentCar.Domain.ValueObjects;

public class Name : ValueObject
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public override string ToString()
    {
        return GetFullName();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}
