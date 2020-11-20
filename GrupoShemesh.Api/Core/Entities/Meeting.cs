using Administration.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Fecha de junta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Tipo de junta")]
        public ETypeMeeting? ETypeMeeting { get; set; }
        public virtual List<MeetingDetails> MeetingDetails { get; set; }
        public virtual List<MeetingParticipants> MeetingParticipants { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
