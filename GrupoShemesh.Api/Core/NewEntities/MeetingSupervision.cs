using GrupoShemesh.Api.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class MeetingSupervision
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El cammpo {0} es requerido")]
        [Display(Name = "Asunto")]
        public string Affair { get; set; }

        [Required(ErrorMessage = "El cammpo {0} es requerido")]
        [Display(Name = "Departamento")]
        public EDepartament Departament { get; set; }
    }
}
