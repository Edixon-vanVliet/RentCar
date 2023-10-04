using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;

namespace RentCar.Application.VehicleTypes.Commands.DeleteVehicleType;

public record DeleteVehicleTypeCommand(int Id) : IRequest<Unit>;

public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteVehicleTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = await _context.VehicleTypes.FirstOrDefaultAsync(vehicleType => vehicleType.Id == request.Id, cancellationToken);

        if (vehicleType == null)
        {
            throw new NotFoundException(nameof(vehicleType), new { request.Id });
        }

        _context.VehicleTypes.Remove(vehicleType);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
