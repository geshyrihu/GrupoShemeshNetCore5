using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Solicitante")]
        [MaxLength(255, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string NameRequest { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
