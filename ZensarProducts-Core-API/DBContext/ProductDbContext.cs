using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZensarProducts_Core_API.Models;

namespace ZensarProducts_Core_API.DBContext
{
    public class ProductDbContext : IdentityDbContext<IdentityUser>
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
