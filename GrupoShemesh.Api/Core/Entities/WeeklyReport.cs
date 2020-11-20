using Administration.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class WeeklyReport
    {
        public int Id { get; set; }

        [Display(Name = "Antes")]
        public string PhotoPathBefore { get; set; }

        [Display(Name = "Después")]
        public string PhotoPathAfter { get; set; }

        [Display(Name = "Fecha de Termino")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFinished { get; set; } = null;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateRequest { get; set; } = null;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Actividad")]
        [DataType(DataType.MultilineText)]
        public string Activity { get; set; }

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Observations { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estatus")]
        public EStatus? Status { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Prioridad")]
        public EPriority? Priority { get; set; }
        public virtual ApplicationUser User { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Responsable")]
        public int ResponsibleAreaId { get; set; }
        public virtual ResponsibleArea ResponsibleArea { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Solicita")]
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }


    }
}
