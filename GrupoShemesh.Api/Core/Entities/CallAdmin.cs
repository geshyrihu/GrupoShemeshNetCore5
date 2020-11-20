using Administration.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{

    public class CallAdmin
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateRequest { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Hora de Solicitud")]
        [DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeRequest { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Departamento")]
        public int DirectoryCondominiumId { get; set; }
        public virtual DirectoryCondominium DirectoryCondominium { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Servicio Solicitado")]
        [DataType(DataType.MultilineText)]
        public string RequestService { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Solicita")]
        public ERequest? Request { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Area Responsable")]
        public int ResponsibleAreaId { get; set; }
        public virtual ResponsibleArea ResponsibleArea { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Responsable")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estatus")]
        public EStatus? Status { get; set; }


        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public String Observations { get; set; }


        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ApplicationUser User { get; set; }

    }

}
