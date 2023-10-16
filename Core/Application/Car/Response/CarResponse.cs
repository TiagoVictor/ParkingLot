using Application.Car.Dto;

namespace Application.Car.Responses;
public class CarResponse : Response
{
    public CarDto Data;
    public List<CarDto> Cars = new();
}
