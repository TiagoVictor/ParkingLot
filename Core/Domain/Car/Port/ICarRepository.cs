namespace Domain.Car.Port
{
    public interface ICarRepository
    {
        Task<int> CreateCarAsync(Entitie.Car car);
        Task<Entitie.Car> UpdateCarAsync(Entitie.Car car);
        Task DeleteCarAsync(Entitie.Car car);
        Task<Entitie.Car> GetCarByIdAsync(int id);
        Task<List<Entitie.Car>> GetCarsAsync();
    }
}