namespace Domain.Car.Exceptions;

public class ManufacturerNullException : Exception
{
    public override string Message => "Manufacturer cannot be null.";
}