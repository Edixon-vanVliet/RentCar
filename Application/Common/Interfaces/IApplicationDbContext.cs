using Microsoft.EntityFrameworkCore;

namespace RentCar.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}