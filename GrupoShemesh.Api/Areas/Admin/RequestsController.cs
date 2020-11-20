using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IGenericRepository<Request> _genericRepository;
        private readonly IAccountRepository _accountRepository;

        public RequestsController(IGenericRepository<Request> genericRepository,
                                  IAccountRepository accountRepository)
        {
            _genericRepository = genericRepository;
            _accountRepository = accountRepository;
        }

        [HttpGet("{id}", Name = "GetRequest")]
        public async Task<ActionResult<Request>> GetAsync(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            return data;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetAll()
        {
            var data = await _genericRepository.GetAsyncAll(null, x => x.OrderBy(x => x.NameRequest));
            return Ok(data);
        }


        [HttpPost("{userId}")]
        public async Task<ActionResult<Request>> Post(string userId, Request model)
        {
            var user = await _accountRepository.GetByIdAsync(userId);
            model.User = user;
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetRequest", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> Put(int id, string userId, Request model)
        {
            var user = await _accountRepository.GetByIdAsync(userId);
            model.Id = id;
            model.User = user;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
