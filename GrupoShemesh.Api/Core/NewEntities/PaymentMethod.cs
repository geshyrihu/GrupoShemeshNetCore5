using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Metodo de Pago
    public class PaymentMethod
    {
        public int id { get; set; }

        [Display(Name = "Metodo de Pago")]
        public string Name { get; set; }

        // .... Lista de Ordenes de compra
        public virtual List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
