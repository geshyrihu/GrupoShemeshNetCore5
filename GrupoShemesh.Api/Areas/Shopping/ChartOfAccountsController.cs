using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Shopping
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartOfAccountsController : ControllerBase
    {
        private readonly IGenericRepository<ChartOfAccount> _genericRepository;

        public ChartOfAccountsController(IGenericRepository<ChartOfAccount> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        // GET: api/ChartOfAccounts
        [HttpGet]
        public async Task<ActionResult<ChartOfAccount[]>> GetChartOfAccounts()
        {
            var data = await _genericRepository.GetAsyncAll(null,x => x.OrderBy(x => x.Account),"");
            return Ok(data);
        }
        [HttpGet("{id}", Name = "GetChartOfAccount")]
        public async Task<ActionResult<ChartOfAccount>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            return model;
        }

        // ... Creacion de Item

        [HttpPost]
        public async Task<ActionResult<ChartOfAccount>> Post(ChartOfAccount model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetChartOfAccount", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ChartOfAccount model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ChartOfAccount>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
