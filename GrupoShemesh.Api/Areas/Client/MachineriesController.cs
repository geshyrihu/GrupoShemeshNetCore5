using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IImgService _imgService;
        private readonly IBaseUrl _baseUrl;

        public MachineriesController(ApplicationDbContext db,
                                     IGenericRepository<Machinery> genericRepository,
                                     IGenericRepository<Customer> customerRepository,
                                     IAccountRepository accountRepository,
                                     IImgService imgService,
                                     IBaseUrl baseUrl)
        {
            _db = db;
            _genericRepository = genericRepository;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _imgService = imgService;
            _baseUrl = baseUrl;
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
        public async Task<ActionResult<Machinery>> Post([FromForm] MachineryDto model)
        {
            var user = await _accountRepository.GetByIdAsync(model.User);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "machinery");
            string pathFull = _baseUrl.GetBaseUrl(path);
            var data = new Machinery
            {
                Brand = model.Brand,
                CategoryId = model.CategoryId,
                CustomerId = model.CustomerId,
                DateOfPurchase = model.DateOfPurchase,
                Model = model.Modelo,
                NameMachinery = model.NameMachinery,
                Observations = model.Observations,
                Serie = model.Serie,
                State = model.State,
                TechnicalSpecifications = model.TechnicalSpecifications,
                Ubication = model.Ubication,
                User = user,
            };
            if (model.Img != null)
            {
                string nameFile = _imgService.SaveFile(model.Img, pathFull, 1280, 720);
                if (model.PhotoPath != null)
                {
                    await _imgService.DeleteFile(pathFull, model.PhotoPath);
                }
                data.PhotoPath = nameFile;
            }
            await _genericRepository.CreateAsync(data);
            return new CreatedAtRouteResult("GetMachinery", new { id = data.Id }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] MachineryDto model)
        {
            var user = await _accountRepository.GetByIdAsync(model.User);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "machinery");
            string pathFull = _baseUrl.GetBaseUrl(path);

            var data = await _genericRepository.GetAsyncById(id);
            data.Brand = model.Brand;
            data.CategoryId = model.CategoryId;
            data.CustomerId = model.CustomerId;
            data.DateOfPurchase = model.DateOfPurchase;
            data.Model = model.Modelo;
            data.NameMachinery = model.NameMachinery;
            data.Observations = model.Observations;
            data.Serie = model.Serie;
            data.State = model.State;
            data.TechnicalSpecifications = model.TechnicalSpecifications;
            data.Ubication = model.Ubication;
            data.User = user;

            if (model.Img != null)
            {
                string nameFile = _imgService.SaveFile(model.Img, pathFull, 1280, 720);
                if (model.PhotoPath != null)
                {
                    await _imgService.DeleteFile(pathFull, model.PhotoPath);
                }
                data.PhotoPath = nameFile;
            }

            await _genericRepository.UpdateAsync(data);
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
