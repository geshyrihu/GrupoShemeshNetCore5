using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationReportsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IGenericRepository<WeeklyReport> _genericRepository;
        private readonly ApplicationDbContext _db;
        private readonly IImgService _imgService;
        private readonly IWeekyReportPanel _weekyReportPanel;
        private readonly IBaseUrl _baseUrl;
        private readonly IWebHostEnvironment _env;

        public OperationReportsController(IAccountRepository accountRepository,
                                          IGenericRepository<WeeklyReport> genericRepository,
                                          ApplicationDbContext db,
                                          IWebHostEnvironment env,
                                          IImgService imgService,
                                          IWeekyReportPanel weekyReportPanel,
                                          IBaseUrl baseUrl)
        {
            _accountRepository = accountRepository;
            _genericRepository = genericRepository;
            _db = db;
            _imgService = imgService;
            _weekyReportPanel = weekyReportPanel;
            _baseUrl = baseUrl;
            _env = env;
        }


        [HttpGet("{id}", Name = "GetOperationReport")]
        public async Task<ActionResult<WeeklyReport>> Get(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;

        }

        [HttpPost]
        public async Task<IList<WeeklyReport>> GetAll([FromBody] PanelDto model)
        {
            var data = await _weekyReportPanel.GetReport(model);
            return data;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<WeeklyReport>> Delete(int id)
        {
            var entity = await _genericRepository.GetAsyncById(id);
            await _genericRepository.DeleteAsync(entity);
            var folderCustomer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == entity.CustomerId);
            var folderImg = Path.Combine(_env.WebRootPath, "img/customers", folderCustomer.Id.ToString(), "report");
            if (entity.PhotoPathAfter != null)
            {
                await _imgService.DeleteFile(folderImg, entity.PhotoPathAfter);
            }
            if (entity.PhotoPathBefore != null)
            {
                await _imgService.DeleteFile(folderImg, entity.PhotoPathBefore);
            }
            return NoContent();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<WeeklyReport>> Post([FromForm] AddOrEditOperationReportDto dto)
        {
            var user = await _accountRepository.GetByIdAsync(dto.User);
            string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "report");
            string pathFull = _baseUrl.GetBaseUrl(path);
            var data = new WeeklyReport
            {
                Activity = dto.Activity,
                DateFinished = dto.DateFinished,
                DateRequest = dto.DateRequest,
                Observations = dto.Observations,
                Priority = dto.Priority,
                RequestId = dto.RequestId,
                ResponsibleAreaId = dto.ResponsibleAreaId,
                Status = dto.Status,
                CustomerId = dto.CustomerId,
                User = user,
            };
            if (dto.ImgUploadAfter != null)
            {
                string nameFile = _imgService.SaveFile(dto.ImgUploadAfter, pathFull, 1280, 720);
                if (dto.PhotoPathAfter != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathAfter);
                }
                data.PhotoPathAfter = nameFile;
            }
            if (dto.ImgUploadBefore != null)
            {
                string nameFile = _imgService.SaveFile(dto.ImgUploadBefore, pathFull, 1280, 720);
                if (dto.PhotoPathBefore != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathBefore);
                }
                data.PhotoPathBefore = nameFile;
            }
            await _genericRepository.CreateAsync(data);
            return new CreatedAtRouteResult("GetOperationReport", new { id = data.Id }, data);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WeeklyReport>> Put(int id, [FromForm] AddOrEditOperationReportDto dto)
        {
            var user = await _accountRepository.GetByIdAsync(dto.User);
            string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "report");
            string pathFull = _baseUrl.GetBaseUrl(path);

            var data = await _genericRepository.GetAsyncById(id);
            data.Activity = dto.Activity;
            data.DateFinished = dto.DateFinished;
            data.DateRequest = dto.DateRequest;
            data.Observations = dto.Observations;
            data.Priority = dto.Priority;
            data.RequestId = dto.RequestId;
            data.ResponsibleAreaId = dto.ResponsibleAreaId;
            data.Status = dto.Status;
            data.CustomerId = dto.CustomerId;
            data.User = user;

            if (dto.ImgUploadAfter != null)
            {
                string nameFile = _imgService.SaveFile(dto.ImgUploadAfter, pathFull, 1280, 720);
                if (dto.PhotoPathAfter != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathAfter);
                }
                data.PhotoPathAfter = nameFile;
            }
            if (dto.ImgUploadBefore != null)
            {
                string nameFile = _imgService.SaveFile(dto.ImgUploadBefore, pathFull, 1280, 720);
                if (dto.PhotoPathBefore != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathBefore);
                }
                data.PhotoPathBefore = nameFile;
            }

            await _genericRepository.UpdateAsync(data);
            return NoContent();

        }



        [HttpPut("PruebaPut/{id}")]
        public async Task<ActionResult> PruebaPut(int id, WeeklyReport model, [FromForm] IFormFile ImgUploadBefore, [FromForm] IFormFile ImgUploadAfter)
        {

            return BadRequest();

        }
    }
}
