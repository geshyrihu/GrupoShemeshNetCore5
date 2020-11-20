using GrupoShemesh.Entities;
using System.Collections.Generic;

namespace GrupoShemesh.Core.DTOs
{
    public class MachineriesIndexDto
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public string Ubication { get; set; }
        public string Categorie { get; set; }
        public int Services { get; set; }
        public virtual List<MaintenanceCalendar> MaintenanceCalendars { get; set; }

    }
}
