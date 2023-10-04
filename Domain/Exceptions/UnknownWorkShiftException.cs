namespace RentCar.Domain.Exceptions;

public class UnknownWorkShiftException : Exception
{
    public UnknownWorkShiftException() : base("Work shift cannot be set to Unknown.")
    {
    }

    public UnknownWorkShiftException(string? message) : base(message)
    {
    }

    public UnknownWorkShiftException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
