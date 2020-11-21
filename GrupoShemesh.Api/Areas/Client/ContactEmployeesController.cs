using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Asistente , GerenteMantenimiento")]
    public class ContactEmployeesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<ContactEmployee> _genericRepository;
        public ContactEmployeesController(IMapper mapper,
                               IGenericRepository<ContactEmployee> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        [HttpGet("{id}", Name = "GetContactEmployee")]
        public async Task<ActionResult<ContactEmployeeDTO>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            var dto = _mapper.Map<ContactEmployeeDTO>(model);
            return dto;
        }

        [HttpGet("GetAsyncAll/{employeeId}")]
        public async Task<ActionResult<ContactEmployeeDTO[]>> GetAsyncAll(int employeeId)
        {
            var data = await _genericRepository.GetAsyncAll(x => x.EmployeeId == employeeId, x => x.OrderBy(x => x.Name), "");
            return _mapper.Map<ContactEmployeeDTO[]>(data);
        }

        [HttpPost]
        public async Task<ActionResult<Bank>> Post(ContactEmployeeAddOrEditDTO dto)
        {
            var model = _mapper.Map<ContactEmployee>(dto);
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetContactEmployee", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ContactEmployeeAddOrEditDTO dto)
        {
            var model = _mapper.Map<ContactEmployee>(dto);
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactEmployee>> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}