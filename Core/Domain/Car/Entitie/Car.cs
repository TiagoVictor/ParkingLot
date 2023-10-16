using Domain.Car.Exceptions;
using Domain.Car.Port;

namespace Domain.Car.Entitie;
public class Car
{
    public int Id { get; set; }
    public string Plate { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }

    public void ValidateState()
    {
        if (string.IsNullOrEmpty(Plate))
            throw new PlateNullException();

        if (string.IsNullOrEmpty(Model))
            throw new ModelNullException();

        if (string.IsNullOrEmpty(Manufacturer))
            throw new ManufacturerNullException();
    }

    public async Task Save(ICarRepository repository)
    {
        ValidateState();

        if (Id == 0)
            Id = await repository.CreateCarAsync(this);
        else
            await repository.UpdateCarAsync(this);
    }
}
