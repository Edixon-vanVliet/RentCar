using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;

namespace RentCar.Application.FuelTypes.Commands.UpdateFuelType;

public record UpdateFuelTypeCommand : IRequest<Unit>
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateFuelTypeCommandHandler : IRequestHandler<UpdateFuelTypeCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateFuelTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateFuelTypeCommand request, CancellationToken cancellationToken)
    {
        var fuelType = await _context.FuelTypes.FirstOrDefaultAsync(fuelType => fuelType.Id == request.Id, cancellationToken);

        if (fuelType == null)
        {
            throw new NotFoundException(nameof(fuelType), new { request.Id });
        }

        fuelType.Name = request.Name;
        fuelType.Description = request.Description;

        _context.FuelTypes.Update(fuelType);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
