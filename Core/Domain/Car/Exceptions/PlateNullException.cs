namespace Domain.Car.Exceptions
{
    public class PlateNullException : Exception
    {
        public override string Message => "Plate cannot be null.";
    }
}