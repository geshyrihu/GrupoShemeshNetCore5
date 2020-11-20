using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Catalogo de cuentas
    public class ChartOfAccount
    {
        public int Id { get; set; }

        [Display(Name = "Cuenta")]
        public string Account { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Codigo Sat")]
        public double CodeSat { get; set; }
    }
}
