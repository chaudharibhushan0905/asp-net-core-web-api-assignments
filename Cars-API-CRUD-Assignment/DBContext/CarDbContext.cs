using Cars_API_CRUD_Assignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_API_CRUD_Assignment.DBContext
{
    public class CarDbContext : IdentityDbContext<IdentityUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Cars> Cars { get; set; }
    }
}
