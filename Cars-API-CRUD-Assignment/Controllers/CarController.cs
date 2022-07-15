using Cars_API_CRUD_Assignment.Models;
using Cars_API_CRUD_Assignment.Repository;
using Cars_API_CRUD_Assignment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CarCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetAllCars();
            if (cars == null)
            {
                NotFound("No Cars Found!!");
            }

            return Ok(cars);
        }

        public IActionResult GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound($"Car with id ={id} is not found");
            }

            return Ok(car);
        }
        [HttpPost]
        public IActionResult AddCar(AddCarViewModels addCarViewModels)
        {
            Cars car = new Cars
            {
                Name = addCarViewModels.Name,
                Category = addCarViewModels.Category,
                Price = addCarViewModels.Price
            };

            var addedCar = _carRepository.AddCar(car);
            return Ok(addedCar);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] UpdateViewModel updateViewModel)
        {
            Cars car= new Cars
            {
                Name = updateViewModel.Name,
                Category = updateViewModel.Category,
                Price = updateViewModel.Price
            };

            bool isCarUpdated = _carRepository.UpdateCar(id, car);

            if (!isCarUpdated)
            {
                return NotFound($"Product with id = {id} is not found.");
            }
            return Ok($"Car with id = {id} is updated successfully.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            bool isCarRemoved = _carRepository.DeleteCar(id);
            if (!isCarRemoved)
            {
                return NotFound($"Car with id = {id} is not found.");
            }
            return Ok($"Car with id = {id} is removed successfully.");
        }

    }
}
