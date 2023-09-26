using RentCar.Application.Common.Interfaces;

namespace RentCar.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}