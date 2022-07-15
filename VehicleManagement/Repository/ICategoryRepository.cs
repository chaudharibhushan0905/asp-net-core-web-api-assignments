using System.Collections.Generic;
using VehicleManagement.Model;

namespace VehicleManagrment.Repository
{
    public interface ICategoryRepository
    {
        List<VCategory> GetAllCategories();
    }
}
