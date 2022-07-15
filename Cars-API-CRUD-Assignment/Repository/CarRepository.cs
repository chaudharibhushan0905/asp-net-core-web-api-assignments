using Cars_API_CRUD_Assignment.DBContext;
using Cars_API_CRUD_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_API_CRUD_Assignment.Repository
{
    public class CarRepository : ICarRepository
    {
        CarDbContext _carDbContext;
        public CarRepository(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public Cars AddCar(Cars car)
        {
            _carDbContext.Cars.Add(car);
            _carDbContext.SaveChanges();
            return car;
        }

        public List<Cars> GetAllCars()
        {
            return _carDbContext.Cars.ToList();
        }

        public Cars GetCarById(int id)
        {
            return _carDbContext.Cars.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateCar(int id, Cars car)
        {
            bool isCarUpdated = false;
            var carTobeUpdated = _carDbContext.Cars.FirstOrDefault(p => p.Id == id);

            if (carTobeUpdated != null)
            {
                carTobeUpdated.Name = car.Name;
                carTobeUpdated.Category = car.Category;
                carTobeUpdated.Price = car.Price;
                _carDbContext.SaveChanges();
                isCarUpdated = true;
            }
            return isCarUpdated;
        }
        public bool DeleteCar(int id)
        {
            bool isCarRemove = false;
            var CarToBeRemove = _carDbContext.Cars.FirstOrDefault(p => p.Id == id);
            if (CarToBeRemove != null)
            {
                _carDbContext.Cars.Remove(CarToBeRemove);
                _carDbContext.SaveChanges();
                isCarRemove = true;
            }
            return (isCarRemove);
        }
    }
}
