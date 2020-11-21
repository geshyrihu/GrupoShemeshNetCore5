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
    public class ProductOutletsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductOutletsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductOutlets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOutlet>>> GetProductOutlets()
        {
            return await _context.ProductOutlets.ToListAsync();
        }

        // GET: api/ProductOutlets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOutlet>> GetProductOutlet(int id)
        {
            var productOutlet = await _context.ProductOutlets.FindAsync(id);

            if (productOutlet == null)
            {
                return NotFound();
            }

            return productOutlet;
        }

        // PUT: api/ProductOutlets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOutlet(int id, ProductOutlet productOutlet)
        {
            if (id != productOutlet.Id)
            {
                return BadRequest();
            }

            _context.Entry(productOutlet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOutletExists(id))
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

        // POST: api/ProductOutlets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductOutlet>> PostProductOutlet(ProductOutlet productOutlet)
        {
            _context.ProductOutlets.Add(productOutlet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductOutlet", new { id = productOutlet.Id }, productOutlet);
        }

        // DELETE: api/ProductOutlets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOutlet(int id)
        {
            var productOutlet = await _context.ProductOutlets.FindAsync(id);
            if (productOutlet == null)
            {
                return NotFound();
            }

            _context.ProductOutlets.Remove(productOutlet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductOutletExists(int id)
        {
            return _context.ProductOutlets.Any(e => e.Id == id);
        }
    }
}
