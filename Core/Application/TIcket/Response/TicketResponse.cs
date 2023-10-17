using Application.Ticket.Dto;

namespace Application.Ticket.Responses;
public class TicketResponse : Response
{
    public TicketDto Data;
    public List<TicketDto> Tickets = new();
}
