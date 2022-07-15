using Microsoft.EntityFrameworkCore;
using VehicleManagement.Model;

namespace VehicleManagement.DBContext
{
    public class VehicleDBContext : DbContext
    {
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VCategory> VehicleCategories { get; set; }
    }
}
