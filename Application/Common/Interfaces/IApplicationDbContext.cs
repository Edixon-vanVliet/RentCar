using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;

namespace RentCar.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; }

    DbSet<Client> Clients { get; }

    DbSet<CreditCard> CreditCards { get; }

    DbSet<Employee> Employees { get; }

    DbSet<FuelType> FuelTypes { get; }

    DbSet<Inspection> Inspections { get; }

    DbSet<Model> Models { get; }

    DbSet<Person> Persons { get; }

    DbSet<Rent> Rents { get; }

    DbSet<Vehicle> Vehicles { get; }

    DbSet<VehicleType> VehicleTypes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
