using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZensarProducts_Core_API.Models;
using ZensarProducts_Core_API.Repository;
using ZensarProducts_Core_API.ViewModels;

namespace ZensarProducts_Core_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        //[Route("/api/product/getproducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            if (products == null)
            {
                NotFound("No Products Found!!");
            }

            return Ok(products);
        }

        [HttpPost]
        //[Route("/api/product/addproduct")]
        public IActionResult AddProduct(AddProductViewModels addProductViewModels)
        {
            Product product = new Product
            {
                Name = addProductViewModels.Name,
                Description = addProductViewModels.Description,
                Amount = addProductViewModels.Amount,
                CreatedBy = HttpContext.User.Identity.Name,
                CreatedDate = DateTime.Now

            };

            var addedPrduct = _productRepository.AddProduct(product);
            return Ok(addedPrduct);
        }
        //[HttpGet("{id}")]
        ////[Route("/api/product/getproductbyid/{id}")]
        //public IActionResult GetProductById(int id)
        //{
        //    var product = _productRepository.GetProductById(id);
        //    if (product == null)
        //    {
        //        return NotFound($"Product with id ={id} is not found");
        //    }

        //    return Ok(product);
        //}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateViewModel updateViewModel)
        {
            Product product = new Product
            {
                Name = updateViewModel.Name,
                Description = updateViewModel.Description,
                Amount = updateViewModel.Amount,
            };

            bool isProductUpdated = _productRepository.UpdateProduct(id, product);

            if (!isProductUpdated)
            {
                return NotFound($"Product with id = {id} is not found.");
            }
            return Ok($"Product with id = {id} is updated successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bool isProductRemoved = _productRepository.DeleteProduct(id);
            if (!isProductRemoved)
            {
                return NotFound($"Product with id = {id} is not found.");
            }
            return Ok($"Product with id = {id} is removed successfully.");
        }

        [HttpGet("{amount}")]
        public IActionResult GetProductByAmount(double amount)
        {
            var product = _productRepository.GetProductByAmount(amount);
            if(product == null)
            {
                return NotFound($"Product with amount>(amount) not found");
            }
            return Ok(product);
        }
    }
}
