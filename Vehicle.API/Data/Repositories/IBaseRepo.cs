using Vehicle.API.Controllers;
using Vehicle.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vehicle.API.Data.Repositories{
     public interface IBaseRepo
    {
        Task<List<Car>> GetCarsAsync();

        Task<bool> DeleteCarAsync(int id);

        Task<bool> AddCarAsync(Car car);

        Task<bool> UpdateCarAsync(Car car);

        Task<Car> GetCarByIdAsync(int id);
    }

}