using Administration.Enum;
using AutoMapper;
using GrupoShemesh.Api.Core;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
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
    public class MeetingsDetailsController : ControllerBase
    {
        private readonly IGenericRepository<MeetingDetails> _genericRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MeetingsDetailsController(IGenericRepository<MeetingDetails> genericRepository,
                                         IAccountRepository accountRepository,
                                         ApplicationDbContext db,
                                         IMapper mapper)
        {
            _genericRepository = genericRepository;
            _accountRepository = accountRepository;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetMeetingsDetail")]
        public async Task<MeetingDetails> Get(int id)
        {
            var data = await _db.MeetingDetails.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }
        [HttpGet("GetAll/{MeetingId}/{status}")]
        public async Task<ActionResult<List<MettingetailsDto>>> GetAll(int meetingId, int status)
        {
            //var data = await _db.MeetingDetails.Where(x => x.MeetingId == meetingId)
            //    .Select(x => new MettingetailsDto
            //    {
            //        Id = x.Id,
            //        ResponsibleAreaId = x.ResponsibleAreaId,
            //        Status = x.Status,
            //        DeliveryDate = String.Format("{0:yyyy-MM-dd}", x.DeliveryDate),
            //        Advance = x.Advance,
            //        Title = x.Title,
            //        RequestService = x.RequestService,
            //        Observations = x.Observations,
            //        MeetingId = x.MeetingId,

            //    }).OrderBy(x => x.Advance).ToListAsync();

            var data = await _genericRepository.GetAsyncAll(x => x.MeetingId == meetingId, x => x.OrderBy(x => x.Advance), "");
            var resutl = _mapper.Map<List<MettingetailsDto>>(data);
            if (status == 0)
            {
                return Ok(resutl);

            }
            else
            {
                var result = data.Where(x => x.Status == EStatus.Pendiente).ToList();
                return Ok(resutl);

            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(MeetingDetails model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetMeetingsDetail", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> Put(int id, string userId, MeetingDetails model)
        {
            var user = await _accountRepository.GetByIdAsync(userId);
            model.User = user;
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
