using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;

            // Inicializa alguns produtos se o banco estiver vazio
            if (_context.Products.Count() == 0)
            {
                _context.Products.Add(new Product { Name = "Product1", Price = 9.99m });
                _context.Products.Add(new Product { Name = "Product2", Price = 19.99m });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}
