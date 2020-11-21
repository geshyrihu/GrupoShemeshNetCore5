using Administration.Enum;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboBoxController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ComboBoxController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<List<Customer>>> ListCustomers()
        {
            return await _db.Customers.Where(x => x.Active && x.Id != 1).OrderBy(x => x.NameCustomer).ToListAsync();
        }

        [HttpGet("Professions")]
        public async Task<ActionResult<List<Profession>>> ListProfessions()
        {
            return await _db.Professions.OrderBy(x => x.NameProfession).ToListAsync();
        }

        [HttpGet("Providers")]
        public async Task<ActionResult<List<ProviderCB>>> ListProviders()
        {
            return await _db.Providers.Select(x => new ProviderCB
            {
                Id = x.Id,
                NameProvider = x.NameProvider
            })
                                      .OrderBy(x => x.NameProvider)
                                      .ToListAsync();
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetSelectList()
        {
            var data = await _db.Category.OrderBy(x => x.NameCotegory).ToListAsync();

            return data;
        }


        [HttpGet("Request")]
        public async Task<ActionResult<IEnumerable<Request>>> ListRequest()
        {
            var data = await _db.Requests.OrderBy(x => x.NameRequest).ToListAsync();
            return data;
        }
        [HttpGet("ResponsibleArea")]
        public async Task<ActionResult<IEnumerable<ResponsibleArea>>> ListResponsibleArea()
        {
            var data = await _db.ResponsibleAreas.OrderBy(x => x.NameArea).ToListAsync();
            return data;
        }

        [HttpGet("Machineries/{customerId}")]
        public async Task<ActionResult<IEnumerable<MachineryCB>>> GetSelectList(int customerId)
        {
            var data = await _db.Machinery.Select(x => new MachineryCB
            {
                Id = x.Id,
                NameMachinery = x.NameMachinery,
                CustomerId = x.CustomerId,

            })
                                          .Where(x => x.CustomerId == customerId)
                                          .OrderBy(x => x.NameMachinery)
                                          .ToListAsync();
            return data;
        }

        [HttpGet("DirectoryCondominium/{customerId}")]
        public async Task<ActionResult<IEnumerable<DirectoryCondominiumCB>>> GetSelectListDirectoryCondominium(int customerId)
        {
            var data = await _db.DirectoryCondominium.Where(x => x.CustomerId == customerId)
                                                     .OrderBy(x => x.Department)
                                                     .ToListAsync();
            var cb = data.Select(x => new DirectoryCondominiumCB
            {
                Id = x.Id,
                FullName = x.FullName,
            }).ToList();
            return cb;
        }
        [HttpGet("Employee/{customerId}")]
        public async Task<ActionResult<IEnumerable<EmployeeCB>>> GetSelectListEmployee(int customerId)
        {
            var data = await _db.Employee.Where(x => x.CustomerId == customerId)
                                         .OrderBy(x => x.Name)
                                         .ToListAsync();
            var cb = data.Select(x => new EmployeeCB
            {
                Id = x.Id,
                FullName = x.FullName,
            }).ToList();
            return cb;
        }
        [HttpGet("ParticipantAdministration/{customerId}")]

        public async Task<IEnumerable<EmployeeParticipantDto>> ParticipantAdministration(int customerId)
        {
            return await _db.Employee.Select(x => new EmployeeParticipantDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                CustomerId = x.CustomerId
            }).Where(x => x.CustomerId == customerId || x.CustomerId == 1).ToListAsync();
        }

        [HttpGet("ParticipantComite/{customerId}")]
        public async Task<ActionResult<List<DirectoryCondominiumParticipantDto>>> ParticipantComite(int customerId)
        {
            var data = await _db.ListCondomino.Where(x => x.DirectoryCondominium.CustomerId == customerId).ToListAsync();
            var result = data.Select(x => new DirectoryCondominiumParticipantDto
            {
                Id = x.Id,
                NameDirectoryCondominium = x.NameDirectoryCondominium

            }).OrderBy(x => x.NameDirectoryCondominium).ToList();

            return result;
        }

        [HttpGet("ListCondomino/{customerId}")]
        public async Task<ActionResult<IEnumerable<ListCondominoDto>>> ListCondomino(int customerId)
        {
            var data = await _db.ListCondomino.Where(x => x.DirectoryCondominium.CustomerId == customerId).ToListAsync();
            var result = data.Select(x => new ListCondominoDto
            {
                Id = x.Id,
                NameDirectoryCondominium = x.NameDirectoryCondominium,
            }).OrderBy(x => x.NameDirectoryCondominium).ToList();
            return result;
        }
        [HttpGet("ListAdministration/{customerId}")]
        public async Task<ActionResult<IEnumerable<ListAdministrationDto>>> ListAdministration(int customerId)
        {
            var data = await _db.Employee.Where(x => x.CustomerId == customerId || x.CustomerId == 1).ToListAsync();
            var result = data.Select(x => new ListAdministrationDto
            {
                Id = x.Id,
                name = x.FullName,
            }).OrderBy(x => x.name).ToList();
            return result;
        }

        [HttpGet("MeetingPositionComite")]
        public async Task<ActionResult<IEnumerable<MeetingPosition>>> MeetingPositionComite()
        {
            return await _db.MeetingPositions.Where(x => x.Business == EBusiness.Comité)
                                                 .OrderBy(X => X.Position)
                                                 .ToListAsync();
        }
        [HttpGet("MeetingPositionAdministration")]
        public async Task<ActionResult<IEnumerable<MeetingPosition>>> MeetingPositionAdministration()
        {
            return await _db.MeetingPositions.Where(x => x.Business == EBusiness.Administración)
                                                 .OrderBy(X => X.Position)
                                                 .ToListAsync();
        }
        [HttpGet("MeetingPositionInvited")]
        public async Task<ActionResult<IEnumerable<MeetingPosition>>> MeetingPositionInvited()
        {
            return await _db.MeetingPositions.Where(x => x.Business == EBusiness.Invitado)
                                                 .OrderBy(X => X.Position)
                                                 .ToListAsync();
        }

        [HttpGet("Bank")]
        public async Task<ActionResult<IEnumerable<Bank>>> Bank()
        {
            return await _db.Banks.OrderBy(X => X.shortName).ToListAsync();
        }


        // ... lista de años en cedulas Presupuestales
        [HttpGet("GetAllYears")]
        public async Task<ActionResult<int[]>> GetAllYears(int year)
        {
            var data = await _db.BudgetCards.GroupBy(x => new { x.Year })
                                            .Select(x => new { x.Key}).ToArrayAsync();
            return Ok(data);
        }

        // ... Catalogo de cuentas

        [HttpGet("GetAllChartOfAccounts")]
        public async Task<ActionResult<ChartOfAccount[]>> GetAllChartOfAccounts()
        {
            var data = await _db.ChartOfAccounts.Select(x => new
            {
                Id = x.Id,
                Description= x.Description
            }).OrderBy(x => x.Description).ToListAsync();
            return Ok(data);
        }
    }
}
