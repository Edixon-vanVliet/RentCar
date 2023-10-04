namespace RentCar.Domain.Entities;

public class FuelType : BaseEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
