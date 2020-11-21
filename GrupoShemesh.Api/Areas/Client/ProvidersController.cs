using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IGenericRepository<Provider> _genericRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IBaseUrl _baseUrl;
        private readonly IImgService _imgService;
        private readonly IMapper _mapper;

        public ProvidersController(IGenericRepository<Provider> genericRepository,
                                   IAccountRepository accountRepository,
                                   IBaseUrl baseUrl,
                                   IImgService imgService,
                                   IMapper mapper)
        {
            _genericRepository = genericRepository;
            _accountRepository = accountRepository;
            _baseUrl = baseUrl;
            _imgService = imgService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetProvider")]
        public async Task<ActionResult<ProviderDTO>> GetAsyncById(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            return _mapper.Map<ProviderDTO>(model);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProviderDTO>>> GetAsyncAll()
        {
            var data = await _genericRepository.GetAsyncAll(null, x => x.OrderBy(x => x.NameProvider), "");
            return _mapper.Map<List<ProviderDTO>>(data);
        }

        [HttpPost]
        public async Task<ActionResult<Provider>> Post([FromForm]ProviderAddOrEditDTO dto)
        {
            var user = await _accountRepository.GetByIdAsync(dto.User);
            var entity = _mapper.Map<Provider>(dto);
            entity.User = user;

            try
            {
                string path = ("img/providers");
                string pathFull = _baseUrl.GetBaseUrl(path);
                if (dto.PathPhoto != null)
                {
                    string nameFile = _imgService.SaveFile(dto.PathPhoto, pathFull, 600, 600);
                    entity.PathPhoto = nameFile;
                }

                var result = await _genericRepository.CreateAsync(entity);
                return new CreatedAtRouteResult("GetProvider", new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm]ProviderAddOrEditDTO dto)
        {
            var entity = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity = _mapper.Map(dto, entity);

            string path = ("img/providers");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (dto.PathPhoto != null)
            {
                string nameFile = _imgService.SaveFile(dto.PathPhoto, pathFull, 600, 600);
                if (entity.PathPhoto != null)
                {
                    await _imgService.DeleteFile(pathFull, entity.PathPhoto.ToString());
                }
                entity.PathPhoto = nameFile;
            }
            await _genericRepository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Provider>> Delete(int id)
        {
            var model = await _genericRepository.DeleteAsync(id);
            string path = ("img/providers");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (model.PathPhoto != null)
            {
                await _imgService.DeleteFile(pathFull, model.PathPhoto);
            }
            return NoContent();
        }



    }
}
