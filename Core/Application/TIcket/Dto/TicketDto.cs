using System.Text.Json.Serialization;
using CarDto = Application.Car.Dto;
using TicketEntity = Domain.Ticket.Entitie;

namespace Application.Ticket.Dto;
public class TicketDto
{
    public int Id { get; set; }
    public DateTime Start { get; set; }

    [JsonIgnore]
    public DateTime End { get; set; } = DateTime.MinValue;

    public CarDto.CarDto Car { get; set; }

    public static TicketEntity.Ticket MapToEntity(TicketDto ticketDto)
    {
        return new TicketEntity.Ticket
        {
            Id = ticketDto.Id,
            Car = new Domain.Car.Entitie.Car
            {
                Id = ticketDto.Car.Id,
                Plate = ticketDto.Car.Plate,
                Model = ticketDto.Car.Model,
                Manufacturer = ticketDto.Car.Manufacturer,
            },
            Start = ticketDto.Start,
            End = DateTime.MinValue,
        };
    }

    public static TicketDto MapToDto(TicketEntity.Ticket ticket)
    {
        return new TicketDto
        {
            Id = ticket.Id,
            Car = new CarDto.CarDto
            {
                Id = ticket.Car.Id,
                Plate = ticket.Car.Plate,
                Model = ticket.Car.Model,
                Manufacturer = ticket.Car.Manufacturer,
            },
            Start = ticket.Start,
            End = (DateTime)ticket.End,
        };
    }
}
