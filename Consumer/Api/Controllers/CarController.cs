using Application;
using Application.Car.Dto;
using Application.Car.Ports;
using Application.Car.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarManager _carManager;

    public CarController(ICarManager carManager)
    {
        _carManager = carManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody] CarDto carDto)
    {
        var request = new CreateCarRequest
        {
            Data = carDto
        };

        var res = await _carManager
            .CreateCarAsync(request);

        if (res.Success) return Created("", res);

        return res.ErrorCodes switch
        {
            ErrorCodes.CAR_INVALID_PLATE => BadRequest(res),
            ErrorCodes.CAR_INVALID_MODEL => BadRequest(res),
            ErrorCodes.CAR_INVALID_MANUFACTURER => BadRequest(res),
            _ => BadRequest(500)
        };
    }

    [HttpPut]
    public async Task<IActionResult> Put(
        [FromBody] CarDto carDto,
        [FromQuery] int id)
    {
        var request = new UpdateCarRequest
        {
            Data = carDto,
            Id = id,
        };

        var res = await _carManager
            .UpdateCarAsync(request);

        if (res.Success) return Ok(res);

        return res.ErrorCodes switch
        {
            ErrorCodes.CAR_INVALID_MANUFACTURER => BadRequest(res),
            ErrorCodes.CAR_INVALID_PLATE => BadRequest(res),
            ErrorCodes.CAR_INVALID_MODEL => BadRequest(res),
            _ => BadRequest(500)
        };
    }

    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _carManager.GetCarsAsync();
        return Ok(cars.Cars);
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == 0)
            return BadRequest(500);

        await _carManager.DeleteCarAsync(id);

        return Ok();
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id == 0)
            return BadRequest(500);

        var car = await _carManager
            .GetCarByIdAsync(id);

        if (!car.Success)
            return Ok(car);
        else
            return Ok(car.Data);
    }
}
