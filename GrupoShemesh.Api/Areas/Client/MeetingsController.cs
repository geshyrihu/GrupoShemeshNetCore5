using Administration.Enum;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IGenericRepository<Meeting> _genericRepository;

        public MeetingsController(ApplicationDbContext db, IGenericRepository<Meeting> genericRepository)
        {
            _db = db;
            _genericRepository = genericRepository;
        }


        [HttpGet("{id}", Name = "GetMetting")]
        public async Task<Meeting> Get(int id)
        {
            var data = await _db.Meetings.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        [HttpGet("GetAll/{customerId}")]
        public async Task<IEnumerable<MeetingsAllDto>> GetAll(int customerId)
        {
            //var data = await _db.Meetings.Where(x => x.CustomerId == customerId).ToListAsync();
            var data = await _db.Meetings.Select(x => new MeetingsAllDto
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Date = x.Date,
                ETypeMeeting = x.ETypeMeeting,
                Issues = x.MeetingDetails.ToList(),
                Pending = x.MeetingDetails.Where(x => x.Status == EStatus.Pendiente).ToList(),
            }).Where(x => x.CustomerId == customerId).OrderByDescending(x => x.Date).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult<MettingDto>> Post(MettingDto model)
        {
            Meeting data = new Meeting()
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Date = model.Date,
                ETypeMeeting = model.ETypeMeeting,
            };
            var entity = await _genericRepository.CreateAsync(data);
            return new CreatedAtRouteResult("GetMetting", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MettingDto model)
        {
            Meeting data = new Meeting()
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Date = model.Date,
                ETypeMeeting = model.ETypeMeeting,
            };
            await _genericRepository.UpdateAsync(data);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Meeting>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
