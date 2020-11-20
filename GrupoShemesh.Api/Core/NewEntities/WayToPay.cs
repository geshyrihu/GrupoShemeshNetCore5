using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Forma de Pago
    public class WayToPay
    {
        public int id { get; set; }

        [Display(Name = "Forma de Pago")]
        public string Name { get; set; }

        // .... Lista de Ordenes de compra
        public virtual List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
