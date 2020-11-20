using System;
using System.ComponentModel.DataAnnotations;


namespace GrupoShemesh.Entities
{
    public class MeetingParticipants
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Posición")]
        public int MeetingPositionId { get; set; }
        public virtual MeetingPosition MeetingPosition { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        public int MeetingId { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
