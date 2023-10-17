using Application.Car.Dto;
using Application.Car.Ports;
using Application.Ticket.Dto;
using Application.Ticket.Port;
using Application.Ticket.Requests;
using Application.Ticket.Responses;
using Domain.Car.Port;
using Domain.Ticket.Exceptions;
using Domain.Ticket.Port;

namespace Application.Ticket;
public class TicketManager : ITicketManager
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ICarRepository _carManager;

    public TicketManager(ICarRepository carManager, ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
        _carManager = carManager;
    }

    public async Task<TicketResponse> CreateTicketAsync(CreateTicketRequest request)
    {
        try
        {
            var ticket = TicketDto.MapToEntity(request.Data);

            ticket.Car = await _carManager.GetCarByPlate(request.Data.Car.Plate) ?? new Domain.Car.Entitie.Car { Plate = request.Data.Car.Plate, Manufacturer = request.Data.Car.Manufacturer, Model = request.Data.Car.Model };


            await ticket.Save(_ticketRepository);
            request.Data.Id = ticket.Id;

            return new TicketResponse
            {
                Success = true,
                Data = request.Data
            };
        }
        catch (CaNullException ex)
        {
            return new TicketResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.TICKET_INVALID_CARID
            };
        }
        catch (EndInvalidException ex)
        {
            return new TicketResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.TICKET_INVALID_END
            };
        }
        catch (StartInvalidException ex)
        {
            return new TicketResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.TICKET_INVALID_START
            };
        }
        catch (Exception)
        {
            return new TicketResponse
            {
                Success = false,
                Message = "There was an error when using Db.",
                ErrorCodes = ErrorCodes.TICKET_COULD_NOT_SAVE
            };
        }
    }

    public Task DeleteTicketAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TicketResponse> GetTicketById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TicketResponse> GetTicketsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TicketResponse> UpdateTicketAsync(UpdateTicketRequest request)
    {
        try
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(request.Id);

            ticket.End = DateTime.UtcNow;
            await ticket.Save(_ticketRepository);

            request.Data.End = (DateTime)ticket.End;

            return new TicketResponse{
                Success = true,
                Data = request.Data
            };
        }
        catch (CaNullException ex)
        {
            return new TicketResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.TICKET_INVALID_CARID
            };
        }
        catch (EndInvalidException ex)
        {
            return new TicketResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.TICKET_INVALID_END
            };
        }
        catch (StartInvalidException ex)
        {
            return new TicketResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.TICKET_INVALID_START
            };
        }
        catch (Exception)
        {
            return new TicketResponse
            {
                Success = false,
                Message = "There was an error when using Db.",
                ErrorCodes = ErrorCodes.TICKET_COULD_NOT_UPDATE
            };
        }
    }
}
