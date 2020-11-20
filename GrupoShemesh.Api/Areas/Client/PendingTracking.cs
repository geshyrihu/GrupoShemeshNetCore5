using Administration.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Entities
{
    public class PendingTracking
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string  Affair { get; set; }
        public EStatus Estatus { get; set; }
        public string Observations { get; set; }

        [Display(Name = "Usuario")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
