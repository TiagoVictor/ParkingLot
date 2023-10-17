using Domain.Ticket.Port;
using Microsoft.EntityFrameworkCore;

namespace Data.Ticket;
public class TicketRepository : ITicketRepository
{
    private readonly ParkingLotDbContext _dbContext;
    public TicketRepository(ParkingLotDbContext dbContext)
    {
        _dbContext = dbContext;    
    }

    public async Task<int> CreateAsync(Domain.Ticket.Entitie.Ticket ticket)
    {
        await _dbContext
            .Tickets
            .AddAsync(ticket);
        
        await _dbContext
            .SaveChangesAsync();

        return ticket.Id;
    }

    public async Task DeleteAsync(Domain.Ticket.Entitie.Ticket ticket)
    {
        _dbContext
            .Tickets
            .Remove(ticket);

        await _dbContext
            .SaveChangesAsync();
    }

    public async Task<Domain.Ticket.Entitie.Ticket> GetTicketByIdAsync(int id) => await _dbContext
        .Tickets
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Domain.Ticket.Entitie.Ticket>> GetTicketsAsync() => await _dbContext.Tickets.ToListAsync();

    public async Task<Domain.Ticket.Entitie.Ticket> UpdateAsync(Domain.Ticket.Entitie.Ticket ticket)
    {
        _dbContext
            .Tickets
            .Update(ticket);

        await _dbContext
            .SaveChangesAsync();

        return ticket;
    }
}
