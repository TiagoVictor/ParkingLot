using Application.Car.Dto;
using Application.Car.Ports;
using Application.Car.Requests;
using Application.Car.Responses;
using Domain.Car.Exceptions;
using Domain.Car.Port;

namespace Application.Car;
public class CarManager : ICarManager
{
    private readonly ICarRepository _carRepository;

    public CarManager(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<CarResponse> CreateCarAsync(CreateCarRequest request)
    {
        try
        {
            var car = CarDto.MapToEntity(request.Data);
            await car.Save(_carRepository);
            request.Data.Id = car.Id;

            return new CarResponse
            {
                Success = true,
                Data = request.Data
            };
        }
        catch (ManufacturerNullException ex)
        {
            return new CarResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.CAR_INVALID_MANUFACTURER
            };
        }
        catch (ModelNullException ex)
        {
            return new CarResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.CAR_INVALID_MODEL
            };
        }
        catch (PlateNullException ex)
        {
            return new CarResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.CAR_INVALID_PLATE
            };
        }
        catch (Exception)
        {
            return new CarResponse
            {
                Success = false,
                Message = "There was an error using DB.",
                ErrorCodes = ErrorCodes.CAR_COULD_NOT_SAVE
            };
        }
    }

    public async Task DeleteCarAsync(int id)
    {
        var car = await _carRepository.GetCarByIdAsync(id);

        if (car == null)
            return;

        await _carRepository.DeleteCarAsync(car);
    }

    public async Task<CarResponse> GetCarByIdAsync(int id)
    {
        var car = await _carRepository.GetCarByIdAsync(id);

        if (car == null)
        {
            return new CarResponse
            {
                Success = false,
                Message = "Car was not found.",
                ErrorCodes = ErrorCodes.CAR_NOT_FOUND,
            };
        }

        return new CarResponse
        {
            Success = true,
            Data = CarDto.MapToDto(car)
        };
    }

    public async Task<CarResponse> GetCarsAsync()
    {
        var cars = await _carRepository.GetCarsAsync();
        var carsResponse = new CarResponse();

        cars.ForEach(x => carsResponse.Cars.Add(CarDto.MapToDto(x)));

        return new CarResponse
        {
            Cars = carsResponse.Cars
        };
    }

    public async Task<CarResponse> UpdateCarAsync(UpdateCarRequest request)
    {
        try
        {
            var car = await _carRepository.GetCarByIdAsync(request.Id);

            if (car == null)
            {
                return new CarResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.CAR_NOT_FOUND,
                    Message = "Car was not found."
                };
            }

            car.Plate = request.Data.Plate;
            car.Manufacturer = request.Data.Manufacturer;
            car.Model = request.Data.Model;

            await car.Save(_carRepository);

            return new CarResponse
            {
                Success = true,
                Data = request.Data,
            };
        }
        catch (ManufacturerNullException ex)
        {
            return new CarResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.CAR_INVALID_MANUFACTURER
            };
        }
        catch (ModelNullException ex)
        {
            return new CarResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.CAR_INVALID_MODEL
            };
        }
        catch (PlateNullException ex)
        {
            return new CarResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCodes = ErrorCodes.CAR_INVALID_PLATE
            };
        }
        catch (Exception)
        {
            return new CarResponse
            {
                Success = false,
                Message = "There was an error using DB.",
                ErrorCodes = ErrorCodes.CAR_COULD_NOT_UPDATE
            };
        }
    }
}
