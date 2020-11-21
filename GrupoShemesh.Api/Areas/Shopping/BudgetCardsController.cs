using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Shopping
{
    [Route("api/[controller]")]
    [ApiController]

    // ...Controlador de cedula Presupuestal
    public class BudgetCardsController : ControllerBase
    {
        private readonly IGenericRepository<BudgetCard> _genericRepository;

        public BudgetCardsController(IGenericRepository<BudgetCard> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet("GetAllAsync/{year}")]
        public async Task<ActionResult<BudgetCard[]>> GetAllAsync(int year)
        {
            var data = await _genericRepository.GetAsyncAll(x => x.Year == year,
                                                            x => x.OrderBy(x => x.Year), "");
            return Ok(data);
        }



        [HttpGet("{id}", Name = "GetBudgetCard")]
        public async Task<ActionResult<BudgetCard>> GetBudgetCard(int id)
        {
            var budgetCard = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (budgetCard == null)
            {
                return NotFound();
            }

            return budgetCard;
        }

        // ... Creacion de Item

        [HttpPost]
        public async Task<ActionResult<BudgetCard>> Post(BudgetCard model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetBudgetCard", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, BudgetCard model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BudgetCard>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
