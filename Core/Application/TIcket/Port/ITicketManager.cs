using Application.Ticket.Requests;
using Application.Ticket.Responses;

namespace Application.Ticket.Port;
public interface ITicketManager
{
    Task<TicketResponse> CreateTicketAsync(CreateTicketRequest request);
    Task<TicketResponse> UpdateTicketAsync(UpdateTicketRequest request);
    Task DeleteTicketAsync(int id);
    Task<TicketResponse> GetTicketById(int id);
    Task<TicketResponse> GetTicketsAsync();
}
