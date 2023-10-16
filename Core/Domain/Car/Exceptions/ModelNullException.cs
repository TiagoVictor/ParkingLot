namespace Domain.Car.Exceptions;

public class ModelNullException : Exception
{
    public override string Message => "Model cannot be null.";
}