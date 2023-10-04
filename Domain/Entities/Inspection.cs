namespace RentCar.Domain.Entities;

public class Inspection : BaseEntity
{
    public required int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public bool HaveScratches { get; set; }

    public required string Fuel { get; set; }

    public required bool HasSpareWheel { get; set; }

    public required bool HasSpareJack { get; set; }

    public required bool HasBrokenGlass { get; set; }

    public required bool IsLeftFrontWheelDamaged { get; set; }

    public required bool IsRightFrontWheelDamaged { get; set; }

    public required bool IsLeftRearWheelDamaged { get; set; }

    public required bool IsRightRearWheelDamaged { get; set; }

    public required DateTime Date { get; set; }

    public required int EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public string? Comment { get; set; }
}
