using Domain.Car.Port;
using Microsoft.EntityFrameworkCore;

namespace Data.Car;
public class CarRepository : ICarRepository
{
    private readonly ParkingLotDbContext _dbContext;

    public CarRepository(ParkingLotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateCarAsync(Domain.Car.Entitie.Car car)
    {
        await _dbContext
            .Cars
            .AddAsync(car);

        await _dbContext
            .SaveChangesAsync();

        return car.Id;
    }

    public async Task DeleteCarAsync(Domain.Car.Entitie.Car car)
    {
        _dbContext
            .Cars
            .Remove(car);

        await _dbContext
            .SaveChangesAsync();
    }

    public Task<Domain.Car.Entitie.Car> GetCarByIdAsync(int id) =>
        _dbContext
            .Cars
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Domain.Car.Entitie.Car> GetCarByPlate(string plate) =>
        await _dbContext
            .Cars
            .FirstOrDefaultAsync(x => x.Plate == plate);


    public async Task<List<Domain.Car.Entitie.Car>> GetCarsAsync() => await
        _dbContext
            .Cars
            .ToListAsync();

    public async Task<Domain.Car.Entitie.Car> UpdateCarAsync(Domain.Car.Entitie.Car car)
    {
        _dbContext
            .Cars
            .Update(car);

        await _dbContext
            .SaveChangesAsync();

        return car;
    }
}
