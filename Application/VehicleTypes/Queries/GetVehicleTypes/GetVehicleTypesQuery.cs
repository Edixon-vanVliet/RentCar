using AutoMapper;
using MediatR;
using RentCar.Application.Common.Interfaces;
using RentCar.Application.Common.Mappings;

namespace RentCar.Application.VehicleTypes.Queries.GetVehicleTypes;

//[Authorize]
public record GetVehicleTypesQuery : IRequest<List<VehicleTypeDto>>
{
}

public class GetVehicleTypesQueryHandler : IRequestHandler<GetVehicleTypesQuery, List<VehicleTypeDto>>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetVehicleTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<VehicleTypeDto>> Handle(GetVehicleTypesQuery request, CancellationToken cancellationToken) =>
        await _context.VehicleTypes.ProjectToListAsync<VehicleTypeDto>(_mapper.ConfigurationProvider, cancellationToken: cancellationToken);
}
