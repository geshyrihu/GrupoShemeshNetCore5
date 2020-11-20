using System;
using System.ComponentModel.DataAnnotations;


namespace GrupoShemesh.Entities
{
    public class ReportSupervision
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "Actividad")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "Maximo {1} caracteres")]
        public string Activity { get; set; }

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "Maximo {1} caracteres")]
        public string Observations { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
