namespace RentCar.Domain.Entities;

public class Vehicle : BaseEntity
{
    public required string Description { get; set; }

    public required string Chassis { get; set; }

    public required string Motor { get; set; }

    public required string Plate { get; set; }

    public required int VehicleTypeId { get; set; }

    public VehicleType? VehicleType { get; set; }

    public required int BrandId { get; set; }

    public Brand? Brand { get; set; }

    public required int ModelId { get; set; }

    public Model? Model { get; set; }

    public required int FuelTypeId { get; set; }

    public FuelType? FuelType { get; set; }
}
