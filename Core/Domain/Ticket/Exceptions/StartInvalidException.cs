namespace Domain.Ticket.Exceptions;
public class StartInvalidException : Exception
{
    public override string Message => "Start cannot be minimum value.";
}
