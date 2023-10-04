using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCar.Domain.Entities;

namespace RentCar.Infrastructure.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.OwnsOne(person => person.Name);
        builder.OwnsOne(
            person => person.Identification,
            identificationBuilder =>
            {
                identificationBuilder.Property(identification => identification.Id).IsRequired();
                identificationBuilder.HasIndex(identification => identification.Id).IsUnique();
            });
    }
}
