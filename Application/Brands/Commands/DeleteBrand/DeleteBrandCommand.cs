using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;

namespace RentCar.Application.Brands.Commands.DeleteBrand;

public record DeleteBrandCommand(int Id) : IRequest<Unit>;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _context.Brands.FirstOrDefaultAsync(brand => brand.Id == request.Id, cancellationToken);

        if (brand == null)
        {
            throw new NotFoundException(nameof(brand), new { request.Id });
        }

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
