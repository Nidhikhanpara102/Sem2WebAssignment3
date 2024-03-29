
using Microsoft.AspNetCore.Mvc;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment3_Nidhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public ProductController(AssignmentDbContext context)
        {
            _context = context;
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _context.Products.ToList();
            if (products.Count == 0)
            {
                return NotFound("No products found");
            }
            return products;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return product;
        }


        // PUT (UPDATE): api/Product/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Invalid product ID");
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            var successMessage = "Product updated successfully";
            return Ok(successMessage);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            var successMessage = $"Product with ID {id} has been deleted successfully";
            return Ok(new { message = successMessage, product });

        
        }
    }
}
