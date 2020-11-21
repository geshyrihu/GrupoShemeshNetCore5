using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperUsuario")]
    public class CustomersController : ControllerBase
    {
        private readonly IBaseUrl _baseUrl;
        private readonly IGenericRepository<Customer> _genericRepository;
        private readonly IImgService _imgService;
        private readonly IMapper _mapper;

        public CustomersController(IBaseUrl baseUrl,
                                   IGenericRepository<Customer> genericRepository,
                                   IImgService imgService,
                                   IMapper mapper
)
        {
            _baseUrl = baseUrl;
            _genericRepository = genericRepository;
            _imgService = imgService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<CustomerGetDto>> GetAsync(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<CustomerGetDto>(data);
        }

        [HttpGet("GetAllAsync/{stateId}")]
        public async Task<ActionResult<CustomerGetDto[]>> GetAllAsync(bool stateId)
        {
            var data = await _genericRepository.GetAsyncAll
                (x => x.Active == stateId && x.Id != 1,
                 x => x.OrderBy(x => x.NameCustomer),
                 "");
            return _mapper.Map<CustomerGetDto[]>(data);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromForm] CustomerAddOrEditDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);

            try
            {
                string path = ("img/administration/customer");
                string pathFull = _baseUrl.GetBaseUrl(path);
                if (dto.PhotoPath != null)
                {
                    string nameFile = _imgService.SaveFile(dto.PhotoPath, pathFull, 600, 600);
                    entity.PhotoPath = nameFile;
                }

                var result = await _genericRepository.CreateAsync(entity);
                return new CreatedAtRouteResult("GetCustomer", new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] CustomerAddOrEditDto dto)
        {
            var entity = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity = _mapper.Map(dto, entity);

            string path = ("img/administration/customer");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (dto.PhotoPath != null)
            {
                string nameFile = _imgService.SaveFile(dto.PhotoPath, pathFull, 600, 600);
                if (entity.PhotoPath != null)
                {
                    await _imgService.DeleteFile(pathFull, entity.PhotoPath);
                }
                entity.PhotoPath = nameFile;
            }
            await _genericRepository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var entity = await _genericRepository.GetAsyncById(id);
            await _genericRepository.DeleteAsync(entity);
            var forderPath = "img/Administration/customer";
            if (entity.PhotoPath != "")
            {
                await _imgService.DeleteFile(forderPath, entity.PhotoPath);
            }
            return NoContent();
        }
    }
}
