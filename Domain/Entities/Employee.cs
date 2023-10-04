namespace RentCar.Domain.Entities;

public class Employee : BaseEntity
{
    public required int PersonId { get; set; }

    public Person? Person { get; set; }

    private WorkShift _workShift;

    public required WorkShift WorkShift
    {
        get => _workShift;
        set
        {
            if (value == WorkShift.Unknown)
            {
                throw new UnknownWorkShiftException();
            }

            _workShift = value;
        }
    }

    public decimal CommissionPercentage { get; set; }

    public required DateTime EntryDate { get; set; }
}
