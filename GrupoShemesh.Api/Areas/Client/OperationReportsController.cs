using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
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
    public class OperationReportsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IGenericRepository<WeeklyReport> _genericRepository;
        private readonly ApplicationDbContext _db;
        private readonly IImgService _imgService;
        private readonly IWeekyReportPanel _weekyReportPanel;
        private readonly IBaseUrl _baseUrl;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public OperationReportsController(IAccountRepository accountRepository,
                                          IGenericRepository<WeeklyReport> genericRepository,
                                          ApplicationDbContext db,
                                          IWebHostEnvironment env,
                                          IImgService imgService,
                                          IWeekyReportPanel weekyReportPanel,
                                          IBaseUrl baseUrl,
                                          IMapper mapper)
        {
            _accountRepository = accountRepository;
            _genericRepository = genericRepository;
            _db = db;
            _imgService = imgService;
            _weekyReportPanel = weekyReportPanel;
            _baseUrl = baseUrl;
            _mapper = mapper;
            _env = env;
        }


        [HttpGet("{id}", Name = "GetOperationReport")]
        public async Task<ActionResult<WeeklyReportDTO>> Get(int id)
        {
            var data = await _genericRepository.GetAsyncById(id);
            if (data == null)
            {
                return NotFound();
            }
            return _mapper.Map<WeeklyReportDTO>(data);
        }

        [HttpPost]
        public async Task<IList<WeeklyReport>> GetAll([FromBody] PanelDto model)
        {
            var data = await _weekyReportPanel.GetReport(model);
            return data;

            //var result = data.GroupBy(x => x.ResponsibleArea.NameArea).Select(x => new {x.Key, WeeklyReport = x.ToList() }).ToList();

            //return Ok(result);
        }



        [HttpPost("GetReport")]
        public async Task<ActionResult<List<WeeklyReportPDFDTO>>> GetReport([FromBody] PanelDto model)
        {
            //var newData = _mapper.Map<List<MeetingDetailsReportDTO>>(data);
            //var result = newData.GroupBy(x => x.ResponsibleArea.NameArea)
            //    .Select(x => new { x.Key, MeetingDetailsReportDTO = x.ToList() })
            //    .ToList();
            //return Ok(result);
            var data = await _weekyReportPanel.GetReport(model);
            var modelDTO = _mapper.Map<List<WeeklyReportPDFDTO>>(data);
            var result = modelDTO.GroupBy(x => x.ResponsibleArea.NameArea)
                .Select(x => new { x.Key, WeeklyReportPDFDTO = x.ToList() })
                .ToList();
            return Ok(result);
        }



        [HttpPost("Create")]
        public async Task<ActionResult<WeeklyReport>> Post([FromForm] WeeklyReportAddOrEditDTO dto)
        {
            var entity = _mapper.Map<WeeklyReport>(dto);
            var user = await _accountRepository.GetByIdAsync(dto.User);
            entity.User = user;
            string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "report");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (dto.PhotoPathAfter != null)
            {
                string nameFile = _imgService.SaveFile(dto.PhotoPathAfter, pathFull, 1280, 720);
                if (dto.PhotoPathAfter != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathAfter.ToString());
                }
                entity.PhotoPathAfter = nameFile;
            }
            if (dto.PhotoPathBefore != null)
            {
                string nameFile = _imgService.SaveFile(dto.PhotoPathBefore, pathFull, 1280, 720);
                if (dto.PhotoPathBefore != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathBefore.ToString());
                }
                entity.PhotoPathBefore = nameFile;
            }
            await _genericRepository.CreateAsync(entity);
            return new CreatedAtRouteResult("GetOperationReport", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WeeklyReport>> Put(int id, [FromForm] WeeklyReportAddOrEditDTO dto)
        {


            var entity = await _genericRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity = _mapper.Map(dto, entity);
            string path = Path.Combine("img/customers", dto.CustomerId.ToString(), "report");
            string pathFull = _baseUrl.GetBaseUrl(path);
            if (dto.PhotoPathAfter != null)
            {
                string nameFile = _imgService.SaveFile(dto.PhotoPathAfter, pathFull, 1280, 720);
                if (dto.PhotoPathAfter != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathAfter.ToString());
                }
                entity.PhotoPathAfter = nameFile;
            }
            if (dto.PhotoPathBefore != null)
            {
                string nameFile = _imgService.SaveFile(dto.PhotoPathBefore, pathFull, 1280, 720);
                if (dto.PhotoPathBefore != null)
                {
                    await _imgService.DeleteFile(pathFull, dto.PhotoPathBefore.ToString());
                }
                entity.PhotoPathBefore = nameFile;
            }
            await _genericRepository.UpdateAsync(entity);
            return NoContent();
        }


        // ...Eliminar reporte
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
    }
}
