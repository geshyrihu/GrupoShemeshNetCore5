using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleAreasController : ControllerBase
    {
        private readonly IGenericRepository<ResponsibleArea> _genericRepository;
        public ResponsibleAreasController(IGenericRepository<ResponsibleArea> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet("{id}", Name = "GetResponsibleArea")]
        public async Task<ActionResult<ResponsibleArea>> GetAsync(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            return data;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsibleArea>>> GetAll()
        {
            var data = await _genericRepository.GetAsyncAll(null, x => x.OrderBy(x => x.NameArea));
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<ResponsibleArea>> Post(ResponsibleArea model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetResponsibleArea", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ResponsibleArea model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponsibleArea>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
