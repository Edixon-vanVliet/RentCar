using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;

namespace RentCar.Application.FuelTypes.Commands.DeleteFuelType;

public record DeleteFuelTypeCommand(int Id) : IRequest<Unit>;

public class DeleteFuelTypeCommandHandler : IRequestHandler<DeleteFuelTypeCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteFuelTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteFuelTypeCommand request, CancellationToken cancellationToken)
    {
        var fuelType = await _context.FuelTypes.FirstOrDefaultAsync(fuelType => fuelType.Id == request.Id, cancellationToken);

        if (fuelType == null)
        {
            throw new NotFoundException(nameof(fuelType), new { request.Id });
        }

        _context.FuelTypes.Remove(fuelType);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
