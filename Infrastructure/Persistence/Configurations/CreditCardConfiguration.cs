using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCar.Domain.Entities;

namespace RentCar.Infrastructure.Persistence.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.OwnsOne(creditCard => creditCard.HolderName);
        builder.HasIndex(creditCard => creditCard.Number).IsUnique();
    }
}
