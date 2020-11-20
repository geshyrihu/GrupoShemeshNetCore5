using Administration.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Core.DTOs
{
    public class MoListDto
    {
        public int Id { get; set; }
        public int MaintenanceCalendarId { get; set; }
        public string Activity { get; set; }
        public string NameMachinery { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExecutionDate { get; set; }
        public EStatus? Status { get; set; }
        public string NameProvider { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
    }
}
