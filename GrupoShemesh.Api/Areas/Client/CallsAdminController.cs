using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Asistente")]
    public class CallsAdminController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IGenericRepository<CallAdmin> _genericRepository;

        public CallsAdminController(ApplicationDbContext db, IGenericRepository<CallAdmin> genericRepository)
        {
            _db = db;
            _genericRepository = genericRepository;
        }

        [HttpGet("{id}", Name = "GetCallAdmin")]
        public async Task<ActionResult<CallAdmin>> GetAsync(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            return data;
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult<IEnumerable<CallAdmin>>> GetAll(int customerId, [FromBody] FilterCallAdminDto dto)
        {

            if (dto.DateStart == null && dto.DateEnd == null)
            {
                dto.DateStart = DateTime.Today.AddMonths(-1);
                dto.DateEnd = DateTime.Today;
            }

            var data = await _db.CallAdmin.Where(x => x.CustomerId == customerId &&
                                                      x.DateRequest >= dto.DateStart &&
                                                      x.DateRequest <= dto.DateEnd).ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<CallAdmin>> Post(CallAdmin model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetCallAdmin", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CallAdmin model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CallAdmin>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
