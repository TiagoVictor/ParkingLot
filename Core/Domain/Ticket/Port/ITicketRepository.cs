namespace Domain.Ticket.Port;
public interface ITicketRepository
{
    Task<int> CreateAsync(Entitie.Ticket ticket);
    Task<Entitie.Ticket> UpdateAsync(Entitie.Ticket ticket);
    Task DeleteAsync(Entitie.Ticket ticket);
    Task<Entitie.Ticket> GetTicketByIdAsync(int id);
    Task<List<Entitie.Ticket>> GetTicketsAsync();
}
