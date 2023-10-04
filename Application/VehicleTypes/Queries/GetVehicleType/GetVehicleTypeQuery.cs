using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;
using RentCar.Application.Common.Security;

namespace RentCar.Application.VehicleTypes.Queries.GetVehicleType;

[Authorize]
public record GetVehicleTypeQuery : IRequest<VehicleTypeDto>
{
    public int Id { get; set; }
}

public class GetVehicleTypeQueryHandler : IRequestHandler<GetVehicleTypeQuery, VehicleTypeDto>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetVehicleTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VehicleTypeDto> Handle(GetVehicleTypeQuery request, CancellationToken cancellationToken)
    {
        var vehicleType = await _context.VehicleTypes.ProjectTo<VehicleTypeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(vehicleType => vehicleType.Id == request.Id, cancellationToken);

        return vehicleType ?? throw new NotFoundException(nameof(vehicleType), new { request.Id });
    }
}
