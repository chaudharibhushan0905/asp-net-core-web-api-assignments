using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManagement.Model;
using VehicleManagement.ViewModel;
using VehicleManagrment.Repository;
using VehicleManagrment.ViewModel;

namespace VehicleManagrment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        IVehicleRepository _vehicleRepository;
        ICategoryRepository _categoryRepository;
        public VehicleController(IVehicleRepository vehicleRepository, ICategoryRepository categoryRepository)
        {
            _vehicleRepository = vehicleRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public IActionResult AddVehicleDetails([FromBody] AddRecordViewModel addRecordViewModel)
        {
            var existingRecords = _vehicleRepository.GetAllVehicleDetails();
            var record = existingRecords?.FirstOrDefault(i => i.Vehicle_Name.ToLower() == addRecordViewModel.Vehicle_Name.ToLower());
            if (record != null)
            {
                return Conflict("Item already exists");
            }
            Vehicle vehicle = new Vehicle
            {
                Vehicle_Name = addRecordViewModel.Vehicle_Name,
                CategoryId = addRecordViewModel.CategoryId,
                Vehicle_Complaint = addRecordViewModel.Vehicle_Complaint,
                CreatedDate = DateTime.Now,
                Repair_Cost = addRecordViewModel.Repair_Cost


            };
            var addedVehicleDetals = _vehicleRepository.AddVehicleDetails(vehicle);
            return Ok($"Vehicle details with Name : {vehicle.Vehicle_Name} is added successfully !!!");
        }

        [HttpGet]
        public IActionResult GetAllVehicleDetails()
        {
            var allVehicleDetailsByUser = _vehicleRepository.GetAllVehicleDetails();
            List<VehicleViewModel> vehicleDetailsListViewModels = new List<VehicleViewModel>();
            foreach (var vehicle in allVehicleDetailsByUser)
            {
                VehicleViewModel vehicleDetailsViewModel = new VehicleViewModel
                {
                    Id = vehicle.Id,
                    Vehicle_Name = vehicle.Vehicle_Name,
                    Vehicle_Category = vehicle.Category.ItemCategory,
                    Vehicle_Complaint = vehicle.Vehicle_Complaint,
                    CreatedDate = vehicle.CreatedDate,
                    Repair_Cost = vehicle.Repair_Cost

                };
                vehicleDetailsListViewModels.Add(vehicleDetailsViewModel);
            }
            if (vehicleDetailsListViewModels.Count == 0)
            {
                return NotFound("No Records Found !!!");
            }

            return Ok(vehicleDetailsListViewModels);
        }

        [HttpGet("{Id}")]
        public IActionResult GetAllVehicleDetailsById(int Id)
        {
            var allVehicleDetailsById = _vehicleRepository.SearchVehicleDetailsById();
            List<VehicleViewModel> vehicleDetailsListViewModels = new List<VehicleViewModel>();
            foreach (var vehicle in allVehicleDetailsById)
            {
                VehicleViewModel vehicleDetailsViewModel = new VehicleViewModel
                {
                    Id = vehicle.Id,
                    Vehicle_Name = vehicle.Vehicle_Name,
                    Vehicle_Category = vehicle.Category.ItemCategory,
                    Vehicle_Complaint = vehicle.Vehicle_Complaint,
                    CreatedDate = vehicle.CreatedDate,
                    Repair_Cost = vehicle.Repair_Cost

                };
                vehicleDetailsListViewModels.Add(vehicleDetailsViewModel);
            }
            if (vehicleDetailsListViewModels.Count == 0)
            {
                return NotFound($"No Record with Id : {Id} Found !!!");
            }

            return Ok(vehicleDetailsListViewModels);
        }
        public IActionResult SearchVehicleDetailsById(int id)
        {
            var vehicle = _vehicleRepository.SearchVehicleDetailsById(id);
            if (vehicle == null)
            {
                return NotFound($"Vehicle with id ={id} is not found");
            }

            return Ok(vehicle);
        }

        [HttpGet("item/{name}")]
        public IActionResult GetAllVehicleDetailsByName(string name)
        {
            var allVehicleDetailsByItemName = _vehicleRepository.SearchVehicleDetailsByName();
            List<VehicleViewModel> vehicleDetailsListViewModels = new List<VehicleViewModel>();
            foreach (var vehicle in allVehicleDetailsByItemName)
            {
                VehicleViewModel vehicleDetailsViewModel = new VehicleViewModel
                {
                    Id = vehicle.Id,
                    Vehicle_Name = vehicle.Vehicle_Name,
                    Vehicle_Category = vehicle.Category.ItemCategory,
                    Vehicle_Complaint = vehicle.Vehicle_Complaint,
                    CreatedDate = vehicle.CreatedDate,
                    Repair_Cost = vehicle.Repair_Cost

                };
                vehicleDetailsListViewModels.Add(vehicleDetailsViewModel);
            }
            if (vehicleDetailsListViewModels.Count == 0)
            {
                return NotFound($"No Record with name : {name} Found !!!");
            }

            return Ok(vehicleDetailsListViewModels);
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveVehicleDetailById(int Id)
        {
            bool recordDeleted = _vehicleRepository.DeleteVehicleDetail(Id);
            if (!recordDeleted)
            {
                return NotFound($"Vehicle details with Id : {Id} not found !!!");
            }
            return Ok($"Vehicle details with Id : {Id} deleted successfully !!!");
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateVehicleDetailsById(int Id, UpdateViewModel updateRecordViewModel)
        {
            Vehicle vehicle = new Vehicle
            {
                Vehicle_Name = updateRecordViewModel.Vehicle_Name,
                CategoryId = updateRecordViewModel.CategoryId,
                Vehicle_Complaint = updateRecordViewModel.Vehicle_Complaint,
                Repair_Cost = updateRecordViewModel.Repair_Cost
            };
            bool isRecordUpdated = _vehicleRepository.UpdateVehicleDetails(Id, vehicle);
            if (!isRecordUpdated)
            {
                return NotFound($"Vehicle details with Id : {Id} not found !!!");
            }
            return Ok($"Vehicle details with Id : {Id} updated successfully !!!");
        }


    }
}
