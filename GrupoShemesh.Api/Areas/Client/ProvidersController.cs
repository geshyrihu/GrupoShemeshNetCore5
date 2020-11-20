using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using GrupoShemesh.Api.Helpers;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IGenericRepository<Provider> _genericRepository;
        private readonly IBaseUrl _baseUrl;
        private readonly IImgService _imgService;

        public ProvidersController(IGenericRepository<Provider> genericRepository,
                                   IBaseUrl baseUrl,
                                   IImgService imgService)
        {
            _genericRepository = genericRepository;
            _baseUrl = baseUrl;
            _imgService = imgService;
        }

        [HttpGet("{id}", Name = "GetProvider")]
        public async Task<ActionResult<Provider>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            return model;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provider>>> GetAsyncAll()
        {
            var data = await _genericRepository.GetAsyncAll(x => x.OrderBy(x => x.NameProvider));
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Provider>> Post(Provider model)
        {
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetProvider", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Provider model)
        {
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Provider>> Delete(int id)
        {
            var model=await _genericRepository.DeleteAsync(id);
            string path = ("img/providers");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (model.PathPhoto != null)
            {
                await _imgService.DeleteFile(pathFull, model.PathPhoto);
            }
            return NoContent();
        }

        [HttpPut("UpdateImg/{id}")]
        public async Task<ActionResult> UpdateImg(int id, [FromForm] IFormFile img)
        {
            var model = await _genericRepository.GetAsyncById(id);
            string path = ("img/providers");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (img != null)
            {
                string nameFile = _imgService.SaveFile(img, pathFull, 600, 600);
                if (model.PathPhoto != null)
                {
                    await _imgService.DeleteFile(pathFull, model.PathPhoto);
                }
                model.PathPhoto= nameFile;
            }
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }


    }
}
