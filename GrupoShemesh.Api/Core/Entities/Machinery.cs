using Administration.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class Machinery
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Equipo")]
        public string NameMachinery { get; set; }

        [Display(Name = "Ubicación")]
        public string Ubication { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Serie")]
        public string Serie { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }


        [Display(Name = "Foto")]
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        public EState? State { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Compra/Instalación el")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Especificaciones Técnicas")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string TechnicalSpecifications { get; set; }

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string Observations { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual List<MaintenanceCalendar> MaintenanceCalendars { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
