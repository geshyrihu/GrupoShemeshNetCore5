using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Asistente , GerenteMantenimiento")]
    public class ListCondominoController : ControllerBase
    {
        private readonly IGenericRepository<ListCondomino> _genericRepository;

        public ListCondominoController(IGenericRepository<ListCondomino> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet("{id}", Name = "GetListCondomino")]
        public async Task<ActionResult<ListCondomino>> GetAsync(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            return model;
        }

        [HttpGet("GetAllAsync/{customerId}")]
        public async Task<ActionResult<IEnumerable<ListCondomino>>> GetAllAsync(int customerId)
        {
            var data = await _genericRepository.GetAsyncAll(x => x.DirectoryCondominium.CustomerId == customerId, 
                                                            x => x.OrderBy(x => x.NameDirectoryCondominium));
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<ListCondomino>> Post(ListCondomino model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetListCondomino", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ListCondomino model)
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
