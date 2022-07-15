using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManagement.DBContext;
using VehicleManagement.Model;

namespace VehicleManagrment.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        VehicleDBContext _vehicleDBContext;
        public VehicleRepository(VehicleDBContext vehicleDBContext)
        {
            _vehicleDBContext = vehicleDBContext;
        }

        public Vehicle AddVehicleDetails(Vehicle vehicle)
        {
            _vehicleDBContext.Vehicles.Add(vehicle);
            _vehicleDBContext.SaveChanges();
            return vehicle;
        }

        public List<Vehicle> GetAllVehicleDetails()
        {
            return _vehicleDBContext.Vehicles.Include(x => x.Category).ToList();
        }

        public List<Vehicle> SearchVehicleDetailsById(int Id)
        {
            return _vehicleDBContext.Vehicles.Include(x => x.Category).ToList();
        }

        public List<Vehicle> SearchVehicleDetailsByName(string name)
        {
            return _vehicleDBContext.Vehicles.Include(x => x.Category).ToList();
        }

        public bool UpdateVehicleDetails(int Id, Vehicle vehicle)
        {
            bool isRecordUpdated = false;
            var recordToBeUpdated = _vehicleDBContext.Vehicles.FirstOrDefault(x => x.Id == Id);
            if (recordToBeUpdated != null)
            {
                recordToBeUpdated.Vehicle_Name = vehicle.Vehicle_Name;
                recordToBeUpdated.CategoryId = vehicle.CategoryId;
                recordToBeUpdated.Vehicle_Complaint = vehicle.Vehicle_Complaint;
                recordToBeUpdated.Repair_Cost = vehicle.Repair_Cost;
                _vehicleDBContext.SaveChanges();
                isRecordUpdated = true;
            }
            return isRecordUpdated;

        }
        public bool DeleteVehicleDetail(int Id)
        {
            bool isRecordDeleted = false;
            var recordToBeDeleted = _vehicleDBContext.Vehicles.FirstOrDefault(x => x.Id == Id);
            if (recordToBeDeleted != null)
            {
                _vehicleDBContext.Vehicles.Remove(recordToBeDeleted);
                _vehicleDBContext.SaveChanges();
                isRecordDeleted = true;
            }
            return isRecordDeleted;

        }
    }
}
