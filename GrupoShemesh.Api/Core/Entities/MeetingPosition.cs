using Administration.Enum;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class MeetingPosition
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Empresa")]
        public EBusiness? Business { get; set; }

        public string Position { get; set; }


    }
}
