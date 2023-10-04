namespace RentCar.Domain.Entities;

public class Person : BaseEntity
{
    public required Name Name { get; set; }

    public required Identification Identification { get; set; }
}