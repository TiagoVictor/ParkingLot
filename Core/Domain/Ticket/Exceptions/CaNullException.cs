namespace Domain.Ticket.Exceptions;
public class CaNullException : Exception
{
    public override string Message => "CarId cannot be null.";
}
