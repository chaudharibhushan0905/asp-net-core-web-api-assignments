using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZensarProducts_Core_API.Models;

namespace ZensarProducts_Core_API.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        //Product GetProductById(int id);
        bool DeleteProduct(int id);
        bool UpdateProduct(int id, Product product);
        List<Product> GetProductByAmount(double amount);
    }
}
