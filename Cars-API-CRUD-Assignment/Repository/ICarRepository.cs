using Cars_API_CRUD_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Cars_API_CRUD_Assignment.Repository
{
    public interface ICarRepository
    {
        List<Cars> GetAllCars();
        Cars AddCar(Cars product);
        Cars GetCarById(int id);
        bool DeleteCar(int id);
        bool UpdateCar(int id, Cars car);
    }
}
