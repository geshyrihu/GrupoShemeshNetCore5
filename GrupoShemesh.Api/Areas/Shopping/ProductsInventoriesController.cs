using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Shopping
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsInventoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductsInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsInventory>>> GetProductsInventories()
        {
            return await _context.ProductsInventories.ToListAsync();
        }

        // GET: api/ProductsInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsInventory>> GetProductsInventory(int id)
        {
            var productsInventory = await _context.ProductsInventories.FindAsync(id);

            if (productsInventory == null)
            {
                return NotFound();
            }

            return productsInventory;
        }

        // PUT: api/ProductsInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsInventory(int id, ProductsInventory productsInventory)
        {
            if (id != productsInventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(productsInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsInventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductsInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsInventory>> PostProductsInventory(ProductsInventory productsInventory)
        {
            _context.ProductsInventories.Add(productsInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsInventory", new { id = productsInventory.Id }, productsInventory);
        }

        // DELETE: api/ProductsInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsInventory(int id)
        {
            var productsInventory = await _context.ProductsInventories.FindAsync(id);
            if (productsInventory == null)
            {
                return NotFound();
            }

            _context.ProductsInventories.Remove(productsInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsInventoryExists(int id)
        {
            return _context.ProductsInventories.Any(e => e.Id == id);
        }
    }
}
