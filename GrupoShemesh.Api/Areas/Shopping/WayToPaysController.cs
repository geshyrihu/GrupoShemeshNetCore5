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
    public class WayToPaysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WayToPaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WayToPays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WayToPay>>> GetWayToPays()
        {
            return await _context.WayToPays.ToListAsync();
        }

        // GET: api/WayToPays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WayToPay>> GetWayToPay(int id)
        {
            var wayToPay = await _context.WayToPays.FindAsync(id);

            if (wayToPay == null)
            {
                return NotFound();
            }

            return wayToPay;
        }

        // PUT: api/WayToPays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWayToPay(int id, WayToPay wayToPay)
        {
            if (id != wayToPay.Id)
            {
                return BadRequest();
            }

            _context.Entry(wayToPay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WayToPayExists(id))
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

        // POST: api/WayToPays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WayToPay>> PostWayToPay(WayToPay wayToPay)
        {
            _context.WayToPays.Add(wayToPay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWayToPay", new { id = wayToPay.Id }, wayToPay);
        }

        // DELETE: api/WayToPays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWayToPay(int id)
        {
            var wayToPay = await _context.WayToPays.FindAsync(id);
            if (wayToPay == null)
            {
                return NotFound();
            }

            _context.WayToPays.Remove(wayToPay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WayToPayExists(int id)
        {
            return _context.WayToPays.Any(e => e.Id == id);
        }
    }
}
