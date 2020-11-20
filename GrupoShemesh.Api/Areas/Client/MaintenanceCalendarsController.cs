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
    public class MaintenanceCalendarsController : ControllerBase
    {
        private readonly IGenericRepository<MaintenanceCalendar> _genericRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ApplicationDbContext _db;

        public MaintenanceCalendarsController(IGenericRepository<MaintenanceCalendar> genericRepository,
                                              IAccountRepository accountRepository,
                                              ApplicationDbContext db)
        {
            _genericRepository = genericRepository;
            _accountRepository = accountRepository;
            _db = db;
        }

        [HttpGet("Get/{id}", Name = "GetMaintenanceCalendar")]
        public async Task<ActionResult<MaintenanceCalendar>> Get(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpGet("GetOfMachinery/{machineryId}")]
        public async Task<ActionResult<IEnumerable<MaintenanceCalendarDto>>> GetOfMachinery(int machineryId)
        {
            var data = await _db.MaintenanceCalendars.Where(x => x.MachineryId == machineryId)
                                                     .OrderBy(x => x.Month)
                                                     .ToListAsync();

            var answer = data.Select(x => new MaintenanceCalendarDto
            {
                Id = x.Id,
                Activity = x.Activity,
                Day = x.Day.ToString(),
                Month = x.Month.ToString(),
                NameMachinery = x.Machinery.NameMachinery,
                Recurrence = x.Recurrence.ToString(),
                CustomerId = x.CustomerId

            }).ToList();

            return answer;
        }

        [HttpGet("{CustomerId}/{month}")]
        public async Task<ActionResult<IEnumerable<MaintenanceCalendar>>> GetAll(int CustomerId, EMonth month)
        {
            var data = await _db.MaintenanceCalendars
                         .Where(x => x.CustomerId == CustomerId && x.Month == month)
                         .OrderBy(x => x.Machinery.NameMachinery)
                         .ToListAsync();
            //var datos = data.Where(x => x.Month == month).ToList();
            return data;
        }


        [HttpPost("{userId}")]
        public async Task<ActionResult<Bank>> Post(string userId, MaintenanceCalendar model)
        {
            var user = await _accountRepository.GetByIdAsync(userId);
            model.User = user;
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetMaintenanceCalendar", new { id = entity.Id }, entity);
        }

        [HttpPut("{userId}/{id}")]
        public async Task<IActionResult> Put(string userId, int id, MaintenanceCalendar model)
        {
            model.Id = id;
            var user = await _accountRepository.GetByIdAsync(userId);
            model.User = user;
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

