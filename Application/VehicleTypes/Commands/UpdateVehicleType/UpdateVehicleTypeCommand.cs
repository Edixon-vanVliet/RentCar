using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;

namespace RentCar.Application.VehicleTypes.Commands.UpdateVehicleType;

public record UpdateVehicleTypeCommand : IRequest<Unit>
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateVehicleTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = await _context.VehicleTypes.FirstOrDefaultAsync(vehicleType => vehicleType.Id == request.Id, cancellationToken);

        if (vehicleType == null)
        {
            throw new NotFoundException(nameof(vehicleType), new { request.Id });
        }

        vehicleType.Name = request.Name;
        vehicleType.Description = request.Description;

        _context.VehicleTypes.Update(vehicleType);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
