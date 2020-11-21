using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
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
    public class ToolsController : ControllerBase
    {
        private readonly IGenericRepository<Tool> _genericRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IImgService _imgService;
        private readonly IBaseUrl _baseUrl;
        private readonly IMapper _mapper;

        public ToolsController(
                               IGenericRepository<Tool> genericRepository,
                               IAccountRepository accountRepository,
                               IImgService imgService,
                               IBaseUrl baseUrl,
                               IMapper mapper)
        {
            _genericRepository = genericRepository;
            _accountRepository = accountRepository;
            _imgService = imgService;
            _baseUrl = baseUrl;
            _mapper = mapper;
        }

        [HttpGet("Get/{id}", Name = "GetTool")]
        public async Task<ActionResult<ToolDTO>> Get(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<ToolDTO>(data);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<List<ToolDTO>>> GetAll(int customerId)
        {
            if (customerId == 0)
            {
                return NotFound();
            }
            var data = await _genericRepository.GetAsyncAll(x => x.CustomerId == customerId,
                                                            x => x.OrderBy(x => x.NameTool),
                                                            "");
            return _mapper.Map<List<ToolDTO>>(data);
        }

        [HttpPost]
        public async Task<ActionResult<Tool>> Post([FromForm] ToolAddOrEditDTO dto)
        {
            var user = await _accountRepository.GetByIdAsync(dto.User);
            var entity = _mapper.Map<Tool>(dto);
            entity.User = user;
            try
            {
                string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "tools");
                string pathFull = _baseUrl.GetBaseUrl(path);
                if (dto.PhotoPath != null)
                {
                    string nameFile = _imgService.SaveFile(dto.PhotoPath, pathFull, 600, 600);
                    entity.PhotoPath = nameFile;
                }

                var result = await _genericRepository.CreateAsync(entity);
                return new CreatedAtRouteResult("GetTool", new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ToolAddOrEditDTO dto)
        {
            var entity = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity = _mapper.Map(dto, entity);

            string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "tools");
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
            var model = await _genericRepository.DeleteAsync(id);
            string path = Path.Combine("img/customers", model.CustomerId.ToString(), "tools");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (model.PhotoPath != "")
            {
                await _imgService.DeleteFile(pathFull, model.PhotoPath);
            }
            return NoContent();
        }
    }
}
