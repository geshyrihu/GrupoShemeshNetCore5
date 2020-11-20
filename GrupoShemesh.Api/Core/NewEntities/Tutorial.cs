using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Entities
{
    public class Tutorial
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Ruta de video")]
        public string Path { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Profesión")]
        public int ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Usuario")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
