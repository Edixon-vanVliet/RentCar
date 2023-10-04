namespace RentCar.Domain.Entities;

public class Rent : BaseEntity
{
    public required Guid TransactionId { get; set; }

    public required int EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public required int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public required int ClientId { get; set; }

    public Client? Client { get; set; }

    public required DateTime RentDate { get; set; }

    public required DateTime ReturnDate { get; set; }

    public required decimal PricePerDay { get; set; }

    public required int Days { get; set; }

    public required int ExtraordinaryDays { get; set; }

    public string? Comment { get; set; }
}
