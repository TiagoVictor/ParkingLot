namespace Domain.Ticket.Exceptions;
public class EndInvalidException : Exception
{
    public override string Message => "End cannot be minimum value.";
}
