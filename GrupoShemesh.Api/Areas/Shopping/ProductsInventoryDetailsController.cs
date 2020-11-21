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
    public class ProductsInventoryDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsInventoryDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductsInventoryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsInventoryDetail>>> GetProductsInventoryDetails()
        {
            return await _context.ProductsInventoryDetails.ToListAsync();
        }

        // GET: api/ProductsInventoryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsInventoryDetail>> GetProductsInventoryDetail(int id)
        {
            var productsInventoryDetail = await _context.ProductsInventoryDetails.FindAsync(id);

            if (productsInventoryDetail == null)
            {
                return NotFound();
            }

            return productsInventoryDetail;
        }

        // PUT: api/ProductsInventoryDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsInventoryDetail(int id, ProductsInventoryDetail productsInventoryDetail)
        {
            if (id != productsInventoryDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(productsInventoryDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsInventoryDetailExists(id))
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

        // POST: api/ProductsInventoryDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsInventoryDetail>> PostProductsInventoryDetail(ProductsInventoryDetail productsInventoryDetail)
        {
            _context.ProductsInventoryDetails.Add(productsInventoryDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsInventoryDetail", new { id = productsInventoryDetail.Id }, productsInventoryDetail);
        }

        // DELETE: api/ProductsInventoryDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsInventoryDetail(int id)
        {
            var productsInventoryDetail = await _context.ProductsInventoryDetails.FindAsync(id);
            if (productsInventoryDetail == null)
            {
                return NotFound();
            }

            _context.ProductsInventoryDetails.Remove(productsInventoryDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsInventoryDetailExists(int id)
        {
            return _context.ProductsInventoryDetails.Any(e => e.Id == id);
        }
    }
}
