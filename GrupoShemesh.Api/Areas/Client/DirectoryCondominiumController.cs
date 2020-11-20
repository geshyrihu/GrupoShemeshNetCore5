using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryCondominiumController : ControllerBase
    {
        private readonly IGenericRepository<DirectoryCondominium> _genericRepository;

        public DirectoryCondominiumController(IGenericRepository<DirectoryCondominium> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        [HttpGet("{id}", Name = "GetDirectoryCondominium")]
        public async Task<ActionResult<DirectoryCondominium>> GetAsync(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            return model;
        }

        [HttpGet("GetAllAsync/{customerId}")]
        public async Task<ActionResult<IEnumerable<DirectoryCondominium>>> GetAllAsync(int customerId)
        {
            var data = await _genericRepository.GetAsyncAll(x => x.CustomerId == customerId, x => x.OrderBy(x => x.Department));
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<DirectoryCondominium>> Post(DirectoryCondominium model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetDirectoryCondominium", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DirectoryCondominium model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bank>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
