namespace RentCar.Domain.Entities;

public class Brand : BaseEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
