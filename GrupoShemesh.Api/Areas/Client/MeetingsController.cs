using Administration.Enum;
using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
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
        private readonly IMapper _mapper;

        public MeetingsController(ApplicationDbContext db,
                                  IGenericRepository<Meeting> genericRepository,
                                  IMapper mapper)
        {
            _db = db;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name = "GetMetting")]
        public async Task<MeetingDTO> Get(int id)
        {
            //var data = await _db.Meetings.FirstOrDefaultAsync(x => x.Id == id);
            var data = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<MeetingDTO>(data);
        }

        [HttpGet("GetMeetingDetails/{idMinuta}")]
        public async Task<ActionResult<List<MeetingDetails>>> GetMeetingDetails(int idMinuta)
        {
            //var result = data.GroupBy(x => x.ResponsibleArea.NameArea).Select(x => new 
            //{x.Key, WeeklyReport = x.ToList() }).ToList();

            var data = await _db.MeetingDetails.Where(x => x.MeetingId == idMinuta).ToListAsync();

            var newData = _mapper.Map<List<MeetingDetailsReportDTO>>(data);
            var result = newData.GroupBy(x => x.ResponsibleArea.NameArea)
                .Select(x => new { x.Key, MeetingDetailsReportDTO = x.ToList() })
                .ToList();
            return Ok(result);
        }



        [HttpGet("GetAll/{customerId}")]
        public async Task<IEnumerable<MeetingsAllDto>> GetAll(int customerId)
        {
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
        public async Task<ActionResult<MeetingDTO>> Post(MeetingDTO dto)
        {
            var data = _mapper.Map<Meeting>(dto);

            var entity = await _genericRepository.CreateAsync(data);
            return new CreatedAtRouteResult("GetMetting", new { id = entity.Id }, entity);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MeetingDTO dto)
        {
            var data = _mapper.Map<Meeting>(dto);
            data.Id = id;
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
