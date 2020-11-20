using Administration.Enum;
using System;
using System.ComponentModel.DataAnnotations;


namespace GrupoShemesh.Entities
{
    public class MaintenanceOrder
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0}es requerido")]
        [Display(Name = "Equipo/Intalación")]
        public int MaintenanceCalendarId { get; set; }
        public virtual MaintenanceCalendar MaintenanceCalendar { get; set; }

        [Required(ErrorMessage = "El campo {0}es requerido")]
        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Fecha de Ejecución")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExecutionDate { get; set; }

        [Required(ErrorMessage = "El campo {0}es requerido")]
        [Display(Name = "Estatus")]
        public EStatus? Status { get; set; }

        [Required(ErrorMessage = "El campo {0}es requerido")]
        [Display(Name = "Proveedor")]
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        [Required(ErrorMessage = "El campo {0}es requerido")]
        [Display(Name = "Costo de Servicio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
