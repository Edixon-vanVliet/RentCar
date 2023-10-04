namespace RentCar.Domain.Entities;

public class Model : BaseEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public required int BrandId { get; set; }

    public Brand? Brand { get; set; }
}
