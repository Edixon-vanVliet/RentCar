using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCar.Application.Common.Exceptions;
using RentCar.Application.Common.Interfaces;
using RentCar.Application.Common.Security;

namespace RentCar.Application.Brands.Queries.GetBrand;

[Authorize]
public record GetBrandQuery : IRequest<BrandDto>
{
    public int Id { get; set; }
}

public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandDto>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetBrandQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var brand = await _context.Brands.ProjectTo<BrandDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(brand => brand.Id == request.Id, cancellationToken);

        return brand ?? throw new NotFoundException(nameof(brand), new { request.Id });
    }
}
