using Entity = Domain.Car.Entitie;

namespace Application.Car.Dto;
public class CarDto
{
    public int Id { get; set; }
    public string Plate { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }

    public static Entity.Car MapToEntity(CarDto carDto)
    {
        return new Entity.Car
        {
            Id = carDto.Id,
            Plate = carDto.Plate,
            Model = carDto.Model,
            Manufacturer = carDto.Manufacturer,
        };
    }

    public static CarDto MapToDto(Entity.Car car)
    {
        return new CarDto
        {
            Id = car.Id,
            Plate = car.Plate,
            Model = car.Model,
            Manufacturer = car.Manufacturer,
        };
    }
}
