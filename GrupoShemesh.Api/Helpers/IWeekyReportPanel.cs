using Administration.Enum;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Helpers
{
    public interface IWeekyReportPanel
    {
        //List<WeeklyReport> GetReport(string customer, EStatus? status, string responsible, string request,
        //                       DateTime? finishedStart, DateTime? requestStart, DateTime? finishedEnd, DateTime? requestEnd, EPriority? priority);
        Task<IList<WeeklyReport>> GetReport(PanelDto model);

    }


    public class WeekyReportPanel : IWeekyReportPanel
    {
        private readonly ApplicationDbContext _context;

        public WeekyReportPanel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<WeeklyReport>> GetReport(PanelDto model)
        {
            // List<WeeklyReport> data = await  _context.WeeklyReport.Where(x => x.Customer.Id == customer && x.CustomerId == model.Customer).ToListAsync();
            List<WeeklyReport> data = null;

            if (model.FinishedEnd == null)
            {
                model.FinishedEnd = DateTime.Now;
            }
            if (model.RequestEnd == null)
            {
                model.RequestEnd = DateTime.Now;
            }
            DateTime? finishedEnd = model.FinishedEnd;
            DateTime? finishedStart = model.FinishedStart;
            DateTime? requestEnd = model.RequestEnd;
            DateTime? requestStart = model.RequestStart;
            EPriority? priority = model.Priority;
            EStatus? status = model.Status;
            int? customer = model.Customer;
            int? request = model.Request;
            int? responsible = model.Responsible;



            //status 
            if (status != null && responsible == null && request == null && finishedStart == null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer && x.Status == status).ToListAsync();
            }
            //responsible
            else if (status == null && responsible != null && request == null && finishedStart == null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer && x.ResponsibleArea.Id == responsible).
                ToListAsync();
            }
            //request
            else if (status == null && responsible == null && request != null && finishedStart == null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request).
                ToListAsync();
            }
            //finishedStart
            else if (status == null && responsible == null && request == null && finishedStart != null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            //requestStart
            else if (status == null && responsible == null && request == null && finishedStart == null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd).
                ToListAsync();
            }
            //priority
            else if (status == null && responsible == null && request == null && finishedStart == null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Priority == priority).
                ToListAsync();
            }

            //------Filter two item------

            //stats responsible

            else if (status != null && responsible != null && request == null && finishedStart == null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.ResponsibleArea.Id == responsible).
                ToListAsync();
            }
            //status request
            else if (status != null && responsible == null && request != null && finishedStart == null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.Request.Id == request).
                ToListAsync();
            }
            //status finishedStart
            else if (status != null && responsible == null && request == null && finishedStart != null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            //status requestStart
            else if (status != null && responsible == null && request == null && finishedStart == null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd).
                ToListAsync();
            }
            //status priority
            else if (status != null && responsible == null && request == null && finishedStart == null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.Priority == priority).
                ToListAsync();
            }

            //responsible request
            else if (status == null && responsible != null && request != null && finishedStart == null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.Request.Id == request).
                ToListAsync();
            }
            //responsible inicial
            else if (status == null && responsible == null && request != null && finishedStart != null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            //responsible requestStart
            else if (status == null && responsible != null && request == null && finishedStart == null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd).
                ToListAsync();
            }
            //responsible priority
            else if (status == null && responsible != null && request == null && finishedStart == null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.Priority == priority).
                ToListAsync();
            }

            //request inicial
            else if (status == null && responsible == null && request != null && finishedStart != null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            //request requestStart
            else if (status == null && responsible == null && request != null && finishedStart == null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd).
                ToListAsync();
            }
            //request priority
            else if (status == null && responsible == null && request != null && finishedStart == null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.Priority == priority).
                ToListAsync();
            }

            //inicial requestStart
            else if (status == null && responsible == null && request == null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            //finishedStart priority
            else if (status == null && responsible == null && request == null && finishedStart != null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.DateRequest >= finishedStart && x.DateRequest <= requestEnd &&
               x.Priority == priority).
                ToListAsync();
            }


            //requestStart priority
            else if (status == null && responsible == null && request == null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.Priority == priority).
                ToListAsync();
            }

            //------filter three item

            //stats responsible request

            else if (status != null && responsible != null && request != null && finishedStart == null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.Request.Id == request).
                ToListAsync();
            }
            //stats responsible finishedStart
            else if (status != null && responsible != null && request == null && finishedStart != null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            //stats responsible finishedStart
            else if (status != null && responsible != null && request == null && finishedStart == null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd).
                ToListAsync();
            }
            //stats responsible Priority
            else if (status != null && responsible != null && request == null && finishedStart == null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.Priority == priority).
                ToListAsync();
            }


            //responsible request finishedStart
            else if (status == null && responsible != null && request != null && finishedStart != null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.ResponsibleArea.Id == responsible &&
               x.Request.Id == request &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            //responsible request requestStart
            else if (status == null && responsible != null && request != null && finishedStart == null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.ResponsibleArea.Id == responsible &&
               x.Request.Id == request &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd).
                ToListAsync();
            }
            //responsible request priority
            else if (status == null && responsible != null && request != null && finishedStart == null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.Request.Id == request &&
              x.Priority == priority).
                ToListAsync();
            }
            //finishedStart requestStart priority
            else if (status == null && responsible == null && request == null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            //finishedStart requestStart status

            else if (status != null && responsible == null && request == null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.Status == status).
                ToListAsync();
            }

            //finishedStart requestStart responsible
            else if (status == null && responsible != null && request == null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.ResponsibleArea.Id == responsible).
                ToListAsync();
            }
            //finishedStart requestStart request
            else if (status == null && responsible == null && request != null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
                x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.Request.Id == request).
                ToListAsync();
            }
            //requestStart priority status
            else if (status != null && responsible == null && request == null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            //requestStart priority responsible
            else if (status == null && responsible != null && request == null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            //requestStart priority request
            else if (status == null && responsible == null && request != null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Request.Id == request &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            //priority status responsible

            else if (status != null && responsible != null && request == null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.Priority == priority).ToListAsync();
            }

            //priority  responsible request
            else if (status == null && responsible != null && request != null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.ResponsibleArea.Id == responsible &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            //priority   request finishedStart
            else if (status == null && responsible == null && request != null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }

            //priority   request finishedStart
            else if (status != null && responsible == null && request == null && finishedStart != null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            //------Filter four items

            // request finishedStart requestStart priority
            else if (status == null && responsible == null && request != null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            // responsible finishedStart requestStart priority
            else if (status == null && responsible != null && request == null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            //responsible request requestStart priority
            else if (status == null && responsible != null && request != null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Request.Id == request &&
               x.ResponsibleArea.Id == responsible &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            //responsible request finishedStart priority
            else if (status == null && responsible != null && request != null && finishedStart != null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Request.Id == request &&
              x.ResponsibleArea.Id == responsible &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            // responsible request finishedStart requestStart 
            else if (status == null && responsible != null && request != null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            // status finishedStart requestStart priority

            else if (status != null && responsible == null && request == null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            // status request requestStart priority
            else if (status != null && responsible == null && request != null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.Request.Id == request &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            // status request finishedStart priority
            else if (status != null && responsible == null && request != null && finishedStart != null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.Request.Id == request &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            // status request finishedStart requestStart 
            else if (status != null && responsible == null && request != null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }
            // status responsible requestStart priority
            else if (status != null && responsible == null && request != null && finishedStart != null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.Request.Id == request &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            // status responsible finishedStart priority
            else if (status != null && responsible != null && request == null && finishedStart != null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            // status responsible request priority
            else if (status != null && responsible != null && request != null && finishedStart == null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.Request.Id == request &&
               x.Priority == priority).
                ToListAsync();
            }
            // status responsible request requestStart
            else if (status != null && responsible != null && request != null && finishedStart == null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.Request.Id == request &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd).
                ToListAsync();
            }
            // status responsible request finishedStart
            else if (status != null && responsible != null && request != null && finishedStart != null && requestStart == null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.Request.Id == request &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }

            // status responsible  finishedStart requestStart
            else if (status != null && responsible != null && request == null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }

            //------Filter five item
            //status request finishedStart requestStart priority

            else if (status != null && responsible == null && request != null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            //status responsible finishedStart requestStart priority
            else if (status != null && responsible != null && request == null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
               x.Priority == priority).
                ToListAsync();
            }
            //status responsible request requestStart priority
            else if (status != null && responsible != null && request != null && finishedStart == null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.ResponsibleArea.Id == responsible &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.Priority == priority).ToListAsync();
            }
            //status responsible request finishedStart priority
            else if (status != null && responsible != null && request != null && finishedStart != null && requestStart == null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.ResponsibleArea.Id == responsible &&
              x.Request.Id == request &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }
            //status responsible request finishedStart requestStart
            else if (status != null && responsible != null && request != null && finishedStart != null && requestStart != null && priority == null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
               x.Status == status &&
               x.ResponsibleArea.Id == responsible &&
               x.Request.Id == request &&
               x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
               x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd).
                ToListAsync();
            }


            //responsible request finishedStart requestStart priority
            else if (status == null && responsible != null && request != null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.ResponsibleArea.Id == responsible &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).
                ToListAsync();
            }

            //------Filter six item
            //stats responsible request finishedStart requestStart priority
            else if (status != null && responsible != null && request != null && finishedStart != null && requestStart != null && priority != null)
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer &&
              x.Status == status &&
              x.ResponsibleArea.Id == responsible &&
              x.Request.Id == request &&
              x.DateRequest >= requestStart && x.DateRequest <= requestEnd &&
              x.DateFinished >= finishedStart && x.DateFinished <= finishedEnd &&
              x.Priority == priority).ToListAsync();
            }

            else
            {
                data = await _context.WeeklyReport.Where(x => x.Customer.Id == customer).
                             OrderByDescending(u => u.Id).
                             ToListAsync();
            }

            return data;
        }
    }


}

