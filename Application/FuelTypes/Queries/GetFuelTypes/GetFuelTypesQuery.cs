using AutoMapper;
using MediatR;
using RentCar.Application.Common.Interfaces;
using RentCar.Application.Common.Mappings;

namespace RentCar.Application.FuelTypes.Queries.GetFuelTypes;

//[Authorize]
public record GetFuelTypesQuery : IRequest<List<FuelTypeDto>>
{
}

public class GetFuelTypesQueryHandler : IRequestHandler<GetFuelTypesQuery, List<FuelTypeDto>>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetFuelTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<FuelTypeDto>> Handle(GetFuelTypesQuery request, CancellationToken cancellationToken) =>
        await _context.FuelTypes.ProjectToListAsync<FuelTypeDto>(_mapper.ConfigurationProvider, cancellationToken: cancellationToken);
}
