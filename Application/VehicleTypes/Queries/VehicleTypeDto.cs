using RentCar.Application.Common.Mappings;
using RentCar.Domain.Entities;

namespace RentCar.Application.VehicleTypes.Queries;

public class VehicleTypeDto : IMapFrom<VehicleType>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
}
