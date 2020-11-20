using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{


    public class Bank
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Codigo")]
        public string code { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Nombre")]
        public string shortName { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Razón Social")]
        public string LargeName { get; set; }
    }
}
