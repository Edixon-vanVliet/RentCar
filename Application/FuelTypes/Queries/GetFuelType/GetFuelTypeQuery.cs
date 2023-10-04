using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;
using RentCar.Application.Common.Security;

namespace RentCar.Application.FuelTypes.Queries.GetFuelType;

[Authorize]
public record GetFuelTypeQuery : IRequest<FuelTypeDto>
{
    public int Id { get; set; }
}

public class GetFuelTypeQueryHandler : IRequestHandler<GetFuelTypeQuery, FuelTypeDto>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetFuelTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FuelTypeDto> Handle(GetFuelTypeQuery request, CancellationToken cancellationToken)
    {
        var fuelType = await _context.FuelTypes.ProjectTo<FuelTypeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(fuelType => fuelType.Id == request.Id, cancellationToken);

        return fuelType ?? throw new NotFoundException(nameof(fuelType), new { request.Id });
    }
}
