using Domain.Ticket.Exceptions;
using Domain.Ticket.Port;

namespace Domain.Ticket.Entitie;
public class Ticket
{
    public int Id { get; set; }
    public Car.Entitie.Car Car { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }

    public void ValidateState()
    {
        if (Car == null)
            throw new CaNullException();

        if (Start == DateTime.MinValue)
            throw new StartInvalidException();

        if (End == null)
            throw new EndInvalidException();
    }

    public async Task Save(ITicketRepository repository)
    {
        ValidateState();

        if (Id == 0)
            Id = await repository.CreateAsync(this);
        else
            await repository.UpdateAsync(this);
    }

}