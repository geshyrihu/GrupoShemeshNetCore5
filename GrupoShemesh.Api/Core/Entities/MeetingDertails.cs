using Administration.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class MeetingDetails
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Area Responsable")]
        public int ResponsibleAreaId { get; set; }
        public virtual ResponsibleArea ResponsibleArea { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Estatus")]
        public EStatus? Status { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Fecha de Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "Avance")]
        public int Advance { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Asunto")]
        [DataType(DataType.MultilineText)]
        public string RequestService { get; set; }
        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Observations { get; set; }
        public int MeetingId { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual ApplicationUser User { get; set; }



    }
}
