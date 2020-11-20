using Administration.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class MaintenanceCalendar
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Equipo")]
        public int MachineryId { get; set; }
        public virtual Machinery Machinery { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Tipo de Mantenimiento")]
        public ETypeMaintance? TypeMaintance { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Recurrencia")]
        public ERecurrence? Recurrence { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Día de Servicio")]
        public EDay? Day { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Mes")]
        public EMonth? Month { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Costo de Servicio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Actividad")]
        [DataType(DataType.MultilineText)]
        public string Activity { get; set; }

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Observation { get; set; }

        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Proveedor")]
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual List<MaintenanceOrder> ListMaintenanceOrder { get; set; }
    }
}
