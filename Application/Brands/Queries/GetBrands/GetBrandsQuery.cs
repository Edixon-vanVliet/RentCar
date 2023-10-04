using AutoMapper;
using MediatR;
using RentCar.Application.Common.Interfaces;
using RentCar.Application.Common.Mappings;
using RentCar.Application.Common.Security;

namespace RentCar.Application.Brands.Queries.GetBrands;

//[Authorize]
public record GetBrandsQuery : IRequest<List<BrandDto>>
{

}

public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, List<BrandDto>>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetBrandsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BrandDto>> Handle(GetBrandsQuery request, CancellationToken cancellationToken) =>
        await _context.Brands.ProjectToListAsync<BrandDto>(_mapper.ConfigurationProvider, cancellationToken: cancellationToken);
}
