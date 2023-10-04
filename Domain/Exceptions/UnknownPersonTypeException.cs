namespace RentCar.Domain.Exceptions;

public class UnknownPersonTypeException : Exception
{
    public UnknownPersonTypeException() : base("Person type cannot be set to Unknown.")
    {
    }

    public UnknownPersonTypeException(string? message) : base(message)
    {
    }

    public UnknownPersonTypeException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
