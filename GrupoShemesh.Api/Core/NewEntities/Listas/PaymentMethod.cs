using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Metodo de Pago
    public class PaymentMethod
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Code { get; set; }

        [Display(Name = "Metodo de Pago")]
        public string Description { get; set; }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
