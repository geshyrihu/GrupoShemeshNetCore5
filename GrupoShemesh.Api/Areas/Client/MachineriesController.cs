using AutoMapper;
using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Mantenimiento")]
    public class MachineriesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IGenericRepository<Machinery> _genericRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IImgService _imgService;
        private readonly IBaseUrl _baseUrl;
        private readonly IMapper _mapper;

        public MachineriesController(ApplicationDbContext db,
                                     IGenericRepository<Machinery> genericRepository,
                                     IAccountRepository accountRepository,
                                     IImgService imgService,
                                     IBaseUrl baseUrl,
                                     IMapper mapper)
        {
            _db = db;
            _genericRepository = genericRepository;
            _accountRepository = accountRepository;
            _imgService = imgService;
            _baseUrl = baseUrl;
            _mapper = mapper;
        }

        [HttpGet("Get/{id}", Name = "GetMachinery")]
        public async Task<ActionResult<Machinery>> Get(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpGet("GetAll/{customerId}")]
        public async Task<ActionResult<IEnumerable<MachineriesIndexDto>>> GetAll(int customerId)
        {
            var data = await _db.Machinery.Where(x => x.CustomerId == customerId).ToListAsync();
            var dto = data.Select(x => new MachineriesIndexDto
            {
                Id = x.Id,
                Categorie = x.Category.NameCotegory,
                Img = x.PhotoPath,
                Name = x.NameMachinery,
                Services = x.MaintenanceCalendars.Count,
                Ubication = x.Ubication,
                MaintenanceCalendars = x.MaintenanceCalendars

            }).OrderBy(x => x.Name).ToList();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<Machinery>> Post([FromForm] MachineryAddOrEditDto dto)
        {
            var user = await _accountRepository.GetByIdAsync(dto.User);
            var entity = _mapper.Map<Machinery>(dto);
            entity.User = user;
            try
            {
                string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "machinery");
                string pathFull = _baseUrl.GetBaseUrl(path);
                if (dto.PhotoPath != null)
                {
                    string nameFile = _imgService.SaveFile(dto.PhotoPath, pathFull, 600, 600);
                    entity.PhotoPath = nameFile;
                }

                var result = await _genericRepository.CreateAsync(entity);
                return new CreatedAtRouteResult("GetMachinery", new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] MachineryAddOrEditDto dto)
        {
            var entity = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity = _mapper.Map(dto, entity);

            string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "machinery");
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            await _genericRepository.DeleteAsync(data);
            string path = Path.Combine("img/customers", data.CustomerId.ToString(), "machinery");
            string pathFull = _baseUrl.GetBaseUrl(path);

            if (data.PhotoPath != null)
            {
                try
                {
                    await _imgService.DeleteFile(pathFull, data.PhotoPath);
                }
                catch (System.Exception)
                {
                    return NoContent();
                }
            }
            return NoContent();
        }
    }
}
