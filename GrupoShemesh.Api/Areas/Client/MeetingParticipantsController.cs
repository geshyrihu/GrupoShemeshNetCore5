using Administration.Enum;
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
    public class MeetingParticipantsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IGenericRepository<MeetingParticipants> _genericRepository;

        public MeetingParticipantsController(ApplicationDbContext db, IGenericRepository<MeetingParticipants> genericRepository)
        {
            _db = db;
            _genericRepository = genericRepository;
        }

        [HttpGet("{id}", Name = "MeetingParticipants")]
        public async Task<ActionResult<MeetingParticipants>> Get(int id)
        {
            return await _genericRepository.GetAsyncById(id);

        }
        [HttpGet("Comite/{meetingId}")]
        public async Task<ActionResult<List<MeetingParticipants>>> Comite(int meetingId)
        {
            var data = await _db.MeetingParticipants
                .Where(x => x.MeetingId == meetingId && x.MeetingPosition.Business == EBusiness.Comité).ToListAsync();

            return data;

        }
        [HttpGet("Administration/{meetingId}")]
        public async Task<ActionResult<List<MeetingParticipants>>> Administration(int meetingId)
        {
            var data = await _db.MeetingParticipants
                .Where(x => x.MeetingId == meetingId && x.MeetingPosition.Business == EBusiness.Administración).ToListAsync();

            return data;

        }
        [HttpGet("Invitado/{meetingId}")]
        public async Task<ActionResult<List<MeetingParticipants>>> Invitado(int meetingId)
        {
            var data = await _db.MeetingParticipants
                .Where(x => x.MeetingId == meetingId && x.MeetingPosition.Business == EBusiness.Invitado).ToListAsync();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MeetingParticipants model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("MeetingParticipants", new { id = entity.Id }, entity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MeetingParticipants model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingParticipants>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }



    }
}
