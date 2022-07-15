using System.Collections.Generic;
using System.Linq;
using VehicleManagement.DBContext;
using VehicleManagement.Model;

namespace VehicleManagrment.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        VehicleDBContext _vehicleDBContext;
        public CategoryRepository(VehicleDBContext vehicleDBContext)
        {
            _vehicleDBContext = vehicleDBContext;
        }

        public List<VCategory> GetAllCategories()
        {
            return _vehicleDBContext.VehicleCategories.ToList();
        }
    }
}
