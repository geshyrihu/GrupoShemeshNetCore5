using Administration.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoShemesh.Core.DTOs
{
    public class MaintenanceCalendarDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NameMachinery { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Recurrence { get; set; }
        public string Activity { get; set; }
    }
}
