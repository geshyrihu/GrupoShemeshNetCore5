using Administration.Enum;
using System;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class MaintenanceOrderDTO
    {
        public int Id { get; set; }

        public int MaintenanceCalendarId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public EStatus? Status { get; set; }
        public int ProviderId { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }

        public string NameMachinery { get; set; }
        public string Activity { get; set; }
  


    }
    public class MaintenanceOrderUpdateDTO
    {

        public int MaintenanceCalendarId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public EStatus? Status { get; set; }
        public int ProviderId { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }

        public string NameMachinery { get; set; }
        public string Activity { get; set; }

    } 
}
