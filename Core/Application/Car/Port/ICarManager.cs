using Application.Car.Requests;
using Application.Car.Responses;

namespace Application.Car.Ports;
public interface ICarManager
{
    Task<CarResponse> CreateCarAsync(CreateCarRequest request);
    Task<CarResponse> UpdateCarAsync(UpdateCarRequest request);
    Task DeleteCarAsync(int id);
    Task<CarResponse> GetCarByIdAsync(int id);
    Task<CarResponse> GetCarsAsync();
    Task<CarResponse> GetCarByPlate(string plate);
}