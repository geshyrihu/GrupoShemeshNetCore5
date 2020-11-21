using Administration.Enum;
using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceOrdersController : ControllerBase
    {
        private readonly IGenericRepository<MaintenanceCalendar> _maintenanceCalendarRepository;
        private readonly IGenericRepository<MaintenanceOrder> _maintenanceOrderRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public MaintenanceOrdersController(IGenericRepository<MaintenanceCalendar> maintenanceCalendarRepository,
                                           IGenericRepository<MaintenanceOrder> maintenanceOrderRepository,
                                           IMapper mapper,
                                           ApplicationDbContext db)
        {
            _maintenanceCalendarRepository = maintenanceCalendarRepository;
            _maintenanceOrderRepository = maintenanceOrderRepository;
            _mapper = mapper;
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<MaintenanceOrder> Get(int id)
        {
            var data = await _maintenanceOrderRepository.GetAsyncById(id);
            return data;
        }
        [HttpGet("GetAll/{idCustomer}/{idMonth}/{idYear}")]
        public async Task<ActionResult<List<MaintenanceOrderDTO>>> GetAll(int idCustomer, int idMonth, int idYear)
        {
            var data = await _db.MaintenanceOrders
                 .Where(x => x.CustomerId == idCustomer && x.RequestDate.Month == idMonth && x.RequestDate.Year == idYear)
                 .OrderBy(x => x.RequestDate)
                 .ToListAsync();

            return _mapper.Map<List<MaintenanceOrderDTO>>(data);
        }

        [HttpPut("{idMaintenanceOrder}")]
        public async Task<ActionResult> Put(int idMaintenanceOrder, [FromBody] MaintenanceOrderUpdateDTO dto)
        {

            var data = await _maintenanceOrderRepository.GetAsyncById(idMaintenanceOrder);
            if (data == null)
            {
                return NotFound();
            }
            data.Price = dto.Price;
            data.ProviderId = dto.ProviderId;
            data.ExecutionDate = dto.ExecutionDate;
            data.Status = dto.Status;


            await _maintenanceOrderRepository.UpdateAsync(data);
            return NoContent();
        }



        [HttpGet("UpdateOrdes/{idCustomer}")]
        public async Task<ActionResult> UpdateOrdes(int idCustomer)
        {
            DateTime todaysDate = DateTime.Now.Date;
            int month = todaysDate.Month - 1;
            int year = todaysDate.Year;
            foreach (EMonth item in Enum.GetValues(typeof(EMonth)))
            {
                //Si coincide el mes actual con el 
                if (month == item.GetHashCode())
                {
                    //Obtenemos la lista de registros que correspondan al mes enviado
                    var mCs = await _maintenanceCalendarRepository
                                          .GetAsyncAll(x => x.CustomerId == idCustomer && x.Month == item,
                                                    x => x.OrderBy(x => x.Machinery.NameMachinery));

                    foreach (var mC in mCs)
                    {
                        // Por cada Calendario creamos una orden de compra 
                        MaintenanceOrder mO = new MaintenanceOrder()
                        {
                            CustomerId = idCustomer,
                            ExecutionDate = null,
                            MaintenanceCalendarId = mC.Id,
                            RequestDate = new DateTime(year, month + 1, 1),
                            Price = mC.Price,
                            ProviderId = mC.ProviderId,
                            Status = EStatus.Pendiente,
                        };
                        //Buscamos regitro que coincida con MaintenanceCalendarId y en la fecha de solicitud coincida por mes y año actual
                        var oS = await _maintenanceOrderRepository.FirstOrDefaultAsync(
                                                      x => x.MaintenanceCalendarId == mC.Id &&
                                                      x.RequestDate.Month == month + 1 &&
                                                      x.RequestDate.Year == year);
                        if (oS == null)
                        {
                            await _maintenanceOrderRepository.CreateAsync(mO);
                        }
                    }
                }
            }
            foreach (EMonth item in Enum.GetValues(typeof(EMonth)))
            {
                //Si coincide el mes actual con el 
                if (month + 1 == item.GetHashCode())
                {
                    //Obtenemos la lista de registros que correspondan al mes enviado
                    var mCs = await _maintenanceCalendarRepository
                                          .GetAsyncAll(x => x.CustomerId == idCustomer && x.Month == item,
                                                    x => x.OrderBy(x => x.Machinery.NameMachinery), "");

                    foreach (var mC in mCs)
                    {
                        // Por cada Calendario creamos una orden de compra 
                        MaintenanceOrder mO = new MaintenanceOrder()
                        {
                            CustomerId = idCustomer,
                            ExecutionDate = null,
                            MaintenanceCalendarId = mC.Id,
                            RequestDate = new DateTime(year, month + 2, 1),
                            Price = mC.Price,
                            ProviderId = mC.ProviderId,
                            Status = EStatus.Pendiente,
                        };
                        //Buscamos regitro que coincida con MaintenanceCalendarId y en la fecha de solicitud coincida por mes y año actual
                        var oS = await _maintenanceOrderRepository.FirstOrDefaultAsync(x => x.MaintenanceCalendarId == mC.Id &&
                                                      x.RequestDate.Month == month + 2 &&
                                                      x.RequestDate.Year == year);
                        if (oS == null)
                        {
                            await _maintenanceOrderRepository.CreateAsync(mO);
                        }
                    }
                }
            }
            return NoContent();
        }

    }
}
