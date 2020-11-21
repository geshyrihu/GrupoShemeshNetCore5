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
    public class UseCFDIsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UseCFDIsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UseCFDIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UseCFDI>>> GetUseCFDIs()
        {
            return await _context.UseCFDIs.ToListAsync();
        }

        // GET: api/UseCFDIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UseCFDI>> GetUseCFDI(int id)
        {
            var useCFDI = await _context.UseCFDIs.FindAsync(id);

            if (useCFDI == null)
            {
                return NotFound();
            }

            return useCFDI;
        }

        // PUT: api/UseCFDIs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUseCFDI(int id, UseCFDI useCFDI)
        {
            if (id != useCFDI.Id)
            {
                return BadRequest();
            }

            _context.Entry(useCFDI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UseCFDIExists(id))
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

        // POST: api/UseCFDIs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UseCFDI>> PostUseCFDI(UseCFDI useCFDI)
        {
            _context.UseCFDIs.Add(useCFDI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUseCFDI", new { id = useCFDI.Id }, useCFDI);
        }

        // DELETE: api/UseCFDIs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUseCFDI(int id)
        {
            var useCFDI = await _context.UseCFDIs.FindAsync(id);
            if (useCFDI == null)
            {
                return NotFound();
            }

            _context.UseCFDIs.Remove(useCFDI);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UseCFDIExists(int id)
        {
            return _context.UseCFDIs.Any(e => e.Id == id);
        }
    }
}
