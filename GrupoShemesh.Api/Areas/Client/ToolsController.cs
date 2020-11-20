using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
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
    public class ToolsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IGenericRepository<Tool> _genericRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IImgService _imgService;
        private readonly IBaseUrl _baseUrl;

        public ToolsController(ApplicationDbContext db,
                               IGenericRepository<Tool> genericRepository,
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

        [HttpGet("Get/{id}", Name = "GetTool")]
        public async Task<ActionResult<Tool>> Get(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<Tool>>> GetAll(int customerId)
        {

            var data = await _db.Tool.Where(x => x.CustomerId == customerId).ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Machinery>> Post([FromForm] ToolDto model)
        {
            var user = await _accountRepository.GetByIdAsync(model.User);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "tool");
            string pathFull = _baseUrl.GetBaseUrl(path);
            var data = new Tool
            {
                Brand = model.Brand,
                CategoryId = model.CategoryId,
                CustomerId = model.CustomerId,
                DateOfPurchase = model.DateOfPurchase,
                Model = model.Modelo,
                NameTool = model.NameTool,
                Observations = model.Observations,
                Serie = model.Serie,
                State = model.State,
                TechnicalSpecifications = model.TechnicalSpecifications,
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
            return new CreatedAtRouteResult("GetTool", new { id = data.Id }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ToolDto model)
        {
            var user = await _accountRepository.GetByIdAsync(model.User);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "tool");
            string pathFull = _baseUrl.GetBaseUrl(path);

            var data = await _genericRepository.GetAsyncById(id);
            data.Brand = model.Brand;
            data.CategoryId = model.CategoryId;
            data.CustomerId = model.CustomerId;
            data.DateOfPurchase = model.DateOfPurchase;
            data.Model = model.Modelo;
            data.NameTool = model.NameTool;
            data.Observations = model.Observations;
            data.Serie = model.Serie;
            data.State = model.State;
            data.TechnicalSpecifications = model.TechnicalSpecifications;
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

            var model = await _genericRepository.DeleteAsync(id);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "tool");
            string pathFull = _baseUrl.GetBaseUrl(path);

            if (model.PhotoPath != "")
            {
                await _imgService.DeleteFile(pathFull, model.PhotoPath);
            }
            return NoContent();

        }


    }
}
