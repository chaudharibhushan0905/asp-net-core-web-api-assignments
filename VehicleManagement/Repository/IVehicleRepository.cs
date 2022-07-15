using System.Collections.Generic;
using VehicleManagement.Model;

namespace VehicleManagrment.Repository
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicleDetails();
        Vehicle AddVehicleDetails(Vehicle vehicle);
        List<Vehicle> SearchVehicleDetailsById(int Id);
        List<Vehicle> SearchVehicleDetailsByName(string name);
        bool DeleteVehicleDetail(int Id);
        bool UpdateVehicleDetails(int Id, Vehicle vehicle);


    }
}
