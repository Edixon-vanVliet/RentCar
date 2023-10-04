namespace RentCar.Domain.Entities;

public class Client : BaseEntity
{
    public required int PersonId { get; set; }

    public Person? Person { get; set; }

    public required int CreditCardId { get; set; }

    public CreditCard? CreditCard { get; set; }

    public required decimal CreditLimit { get; set; }

    private PersonType _personType;

    public required PersonType PersonType
    {
        get => _personType;
        set
        {
            if (value == PersonType.Unknown)
            {
                throw new UnknownPersonTypeException();
            }

            _personType = value;
        }
    }
}
