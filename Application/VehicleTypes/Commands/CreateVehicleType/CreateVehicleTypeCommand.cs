using MediatR;
using RentCar.Application.Common.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.VehicleTypes.Commands.CreateVehicleType;

public record CreateVehicleTypeCommand : IRequest<VehicleType>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, VehicleType>
{
    private readonly IApplicationDbContext _context;

    public CreateVehicleTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<VehicleType> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = new VehicleType
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _context.VehicleTypes.AddAsync(vehicleType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return vehicleType;
    }
}
