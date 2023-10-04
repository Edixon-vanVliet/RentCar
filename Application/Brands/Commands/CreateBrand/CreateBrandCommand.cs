using MediatR;
using RentCar.Application.Common.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Brands.Commands.CreateBrand;

public record CreateBrandCommand : IRequest<Brand>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
{
    private readonly IApplicationDbContext _context;

    public CreateBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _context.Brands.AddAsync(brand, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return brand;
    }
}
