using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Cedula presupuestal
    public class BudgetCard
    {
        public int Id { get; set; }

        [Display(Name = "Año")]
        public int Year { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        // ... Lista de partidas presupuestales por cedula 

        public virtual List<BudgetCardDetail> BudgetCardDetails { get; set; }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
