using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperUsuario")]
    public class BanksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Bank> _genericRepository;
        public BanksController(IMapper mapper,
                               IGenericRepository<Bank> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        [HttpGet("{id}", Name = "GetBank")]
        public async Task<ActionResult<BankDTO>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            var dto = _mapper.Map<BankDTO>(model);
            return dto;
        }

        [HttpGet]
        public async Task<ActionResult<BankDTO[]>> GetAsyncAll()
        {
            var data = await _genericRepository.GetAsyncAll(null, x => x.OrderBy(x => x.shortName), "");
            return _mapper.Map<BankDTO[]>(data);
        }

        [HttpPost]
        public async Task<ActionResult<Bank>> Post(BankAddOrEditDTO dto)
        {
            var model = _mapper.Map<Bank>(dto);
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetBank", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BankAddOrEditDTO dto)
        {
            var model = _mapper.Map<Bank>(dto);
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
