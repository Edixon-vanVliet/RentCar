using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;

namespace RentCar.Application.Brands.Commands.UpdateBrand;

public record UpdateBrandCommand : IRequest<Unit>
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _context.Brands.FirstOrDefaultAsync(brand => brand.Id == request.Id, cancellationToken);

        if (brand == null)
        {
            throw new NotFoundException(nameof(brand), new { request.Id });
        }

        brand.Name = request.Name;
        brand.Description = request.Description;

        _context.Brands.Update(brand);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
