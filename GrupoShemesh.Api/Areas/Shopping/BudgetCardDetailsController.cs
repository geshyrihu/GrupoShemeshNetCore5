using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Shopping
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetCardDetailsController : ControllerBase
    {
        private readonly IGenericRepository<BudgetCardDetail> _genericRepository;

        public BudgetCardDetailsController(IGenericRepository<BudgetCardDetail> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet("GetAllAsync/{budgetCardId}")]
        public async Task<ActionResult<BudgetCardDetail[]>> GetAllAsync(int budgetCardId)
        {
            var data = await _genericRepository.GetAsyncAll(x => x.BudgetCardId == budgetCardId,
                                                            x => x.OrderBy(x => x.ChartOfAccount.Description), "");
            return Ok(data);
        }


        [HttpGet("{id}", Name = "GetBudgetCardDetails")]
        public async Task<ActionResult<BudgetCardDetail>> GetBudgetCard(int id)
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
        public async Task<ActionResult<BudgetCardDetail>> Post(BudgetCardDetail model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetBudgetCardDetails", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, BudgetCardDetail model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BudgetCardDetail>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
