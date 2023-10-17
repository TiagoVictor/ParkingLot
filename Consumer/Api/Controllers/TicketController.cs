using Application;
using Application.Ticket.Dto;
using Application.Ticket.Port;
using Application.Ticket.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketManager _ticketManager;

    public TicketController(ITicketManager ticketManager)
    {
        _ticketManager = ticketManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] TicketDto ticketDto)
    {
        var request = new CreateTicketRequest
        {
            Data = ticketDto
        };

        var res = await _ticketManager
            .CreateTicketAsync(request);

        if (res.Success) return Created("", res);

        return res.ErrorCodes switch
        {
            ErrorCodes.TICKET_INVALID_CARID => BadRequest(res),
            ErrorCodes.TICKET_INVALID_START => BadRequest(res),
            ErrorCodes.TICKET_INVALID_END => BadRequest(res),
            _ => BadRequest(500)
        };
    }

    [HttpPut]
    public async Task<IActionResult> CloseTicket(
        [FromRoute] int id,
        [FromBody] TicketDto ticketDto
    )
    {
        var request = new UpdateTicketRequest
        {
            Id = id,
            Data = ticketDto
        };

        var res = await _ticketManager
        .UpdateTicketAsync(request);

        if (res.Success) return Ok(res);

        return res.ErrorCodes switch
        {
            ErrorCodes.TICKET_INVALID_CARID => BadRequest(res),
            ErrorCodes.TICKET_INVALID_START => BadRequest(res),
            ErrorCodes.TICKET_INVALID_END => BadRequest(res),
            _ => BadRequest(500)
        };
    }
}
