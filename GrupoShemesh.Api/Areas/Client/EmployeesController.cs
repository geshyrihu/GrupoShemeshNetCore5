using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Asistente , GerenteMantenimiento")]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _genericRepository;
        private readonly IBaseUrl _baseUrl;
        private readonly IImgService _imgService;
        private readonly IMapper _mapper;

        public EmployeesController(IGenericRepository<Employee> genericRepository,
                                   IBaseUrl baseUrl,
                                   IImgService imgService,
                                   IMapper mapper)
        {
            _genericRepository = genericRepository;
            _baseUrl = baseUrl;
            _imgService = imgService;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            return model;
        }

        [HttpGet("GetAllAsync/{customerId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllAsync(int customerId)
        {
            var data = await _genericRepository.GetAsyncAll(x => x.CustomerId == customerId,
                                                            x => x.OrderBy(x => x.Name));
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromForm] EmployeeAddOrEditDTO dto)
        {

            var entity = _mapper.Map<Employee>(dto);
            try
            {
                string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "employee");
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
        public async Task<IActionResult> Put(int id, [FromForm] EmployeeAddOrEditDTO dto)
        {
            var entity = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity = _mapper.Map(dto, entity);

            string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "employee");
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
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var model = await _genericRepository.DeleteAsync(id);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "employee");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (model.PhotoPath != null)
            {
                await _imgService.DeleteFile(pathFull, model.PhotoPath);
            }
            return NoContent();
        }


    }
}
