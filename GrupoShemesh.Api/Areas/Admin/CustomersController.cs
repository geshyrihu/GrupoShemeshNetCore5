using AutoMapper;
using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<Customer>> GetAsync(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllAsync()
        {
            var data = await _genericRepository.GetAsyncAll(x => x.OrderBy(x => x.NameCustomer));
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] CustomerPostDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            try
            {
                string path = ("img/administration/customer" );
                string pathFull = _baseUrl.GetBaseUrl(path);
                if (dto.Img != null)
                {
                    string nameFile = _imgService.SaveFile(dto.Img, pathFull, 600, 600);
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
        public async Task<IActionResult> Put(int id, [FromForm] CustomerPostDto dto)
        {
            //var entity = _mapper.Map<Customer>(dto);
            var entity = new Customer()
            {
                Id = dto.Id,
                NameCustomer = dto.NameCustomer,
                RFC = dto.RFC,
                PhoneOne = dto.PhoneOne,
                PhoneTwo = dto.PhoneTwo,
                Adreess = dto.Adreess,
                Register = dto.Register,
                Active = dto.Active,
                PhotoPath = dto.PhotoPath
            };
            entity.Id = id;
            string path = ("img/administration/customer");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (dto.Img != null)
            {
                string nameFile = _imgService.SaveFile(dto.Img, pathFull, 600, 600);
                if (dto.PhotoPath != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPath);
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
