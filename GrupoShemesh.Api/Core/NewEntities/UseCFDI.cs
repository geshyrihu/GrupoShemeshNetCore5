using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Uso de CFDI
    public class UseCFDI
    {
        public int id { get; set; }

        [Display(Name = "Uso de CFDI")]
        public string Name { get; set; }

        // .... Lista de Ordenes de compra
        public virtual List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
