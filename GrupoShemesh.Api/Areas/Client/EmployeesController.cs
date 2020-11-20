using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _genericRepository;
        private readonly IBaseUrl _baseUrl;
        private readonly IImgService _imgService;

        public EmployeesController(IGenericRepository<Employee> genericRepository,
                                   IBaseUrl baseUrl,
                                   IImgService imgService)
        {
            _genericRepository = genericRepository;
            _baseUrl = baseUrl;
            _imgService = imgService;
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
        public async Task<ActionResult<Employee>> Post(Employee model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetEmployee", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
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

        [HttpPut("UpdateImg/{id}")]
        public async Task<ActionResult> UpdateImg(int id, [FromForm] IFormFile img)
        {
            var model = await _genericRepository.GetAsyncById(id);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "employee");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (img != null)
            {
                string nameFile = _imgService.SaveFile(img, pathFull, 600, 600);
                if (model.PhotoPath != null)
                {
                    await _imgService.DeleteFile(pathFull, model.PhotoPath);
                }
                model.PhotoPath = nameFile;
            }
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }
    }
}
