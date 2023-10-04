using System.Reflection;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RentCar.Application.Common.Interfaces;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Identity;
using RentCar.Infrastructure.Persistence.Interceptors;

namespace RentCar.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    public DbSet<Brand> Brands => Set<Brand>();

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<CreditCard> CreditCards => Set<CreditCard>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<FuelType> FuelTypes => Set<FuelType>();

    public DbSet<Inspection> Inspections => Set<Inspection>();

    public DbSet<Model> Models => Set<Model>();

    public DbSet<Person> Persons => Set<Person>();

    public DbSet<Rent> Rents => Set<Rent>();

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();

    private readonly IMediator _mediator;

    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
