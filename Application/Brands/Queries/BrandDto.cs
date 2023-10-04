using RentCar.Application.Common.Mappings;
using RentCar.Domain.Entities;

namespace RentCar.Application.Brands.Queries;

public class BrandDto : IMapFrom<Brand>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
}
