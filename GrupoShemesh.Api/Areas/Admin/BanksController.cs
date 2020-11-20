using AutoMapper;
using GrupoShemesh.Api.Core;
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
        public async Task<ActionResult<BankDto>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            var dto = _mapper.Map<BankDto>(model);
            return dto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankDto>>> GetAsyncAll()
        {
            var data = await _genericRepository.GetAsyncAll(x => x.OrderBy(x => x.shortName));
            var Dto = _mapper.Map<IEnumerable<BankDto>>(data);
            return Ok(Dto);
        }

        [HttpPost]
        public async Task<ActionResult<Bank>> Post(BankDto dto)
        {
            var model = _mapper.Map<Bank>(dto);
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetBank", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BankDto dto)
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
