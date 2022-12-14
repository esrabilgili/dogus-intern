using Vehicle.API.Controllers;
using Vehicle.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vehicle.API.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _context;

        public VehicleRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car is null)
            {
                return false;
            }

            _context.Cars.Remove(car);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<bool> UpdateCarAsync(Car car)
        {
            _context.Update(car);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Car>> GetConditionalAsync(string modelname, int price)
        {
            var cars = await _context.Cars.Where(p=>p.ModelName == modelname && p.Price >= price).ToListAsync();
            return cars;
        }

         public async Task<List<Car>> GetPriceAsync()

        {
            var cars = await _context.Cars.Where(p=>p.Price>1000 && p.Price<2500).ToListAsync();
            return cars;
        }

        public Task UpdateCarAsync()
        {
            throw new NotImplementedException();
        }
    }

}