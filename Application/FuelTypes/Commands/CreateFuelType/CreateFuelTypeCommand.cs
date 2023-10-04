using MediatR;
using RentCar.Application.Common.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.FuelTypes.Commands.CreateFuelType;

public record CreateFuelTypeCommand : IRequest<FuelType>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class CreateFuelTypeCommandHandler : IRequestHandler<CreateFuelTypeCommand, FuelType>
{
    private readonly IApplicationDbContext _context;

    public CreateFuelTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FuelType> Handle(CreateFuelTypeCommand request, CancellationToken cancellationToken)
    {
        var fuelType = new FuelType
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _context.FuelTypes.AddAsync(fuelType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return fuelType;
    }
}
