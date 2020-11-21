using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
   
        private readonly IGenericRepository<Category> _genericRepository;
        public CategoriesController(IGenericRepository<Category> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            return model;
        }

        [HttpGet]
        public async Task<ActionResult<Category[]>> GetAsyncAll()
        {
            var data = await _genericRepository.GetAsyncAll(x => x.OrderBy(x => x.NameCotegory));
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Bank>> Post(Category model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetCategory", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category model)
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
