using RentCar.Application.Common.Mappings;
using RentCar.Domain.Entities;

namespace RentCar.Application.FuelTypes.Queries;

public class FuelTypeDto : IMapFrom<FuelType>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
}
