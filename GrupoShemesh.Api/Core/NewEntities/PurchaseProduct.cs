using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{

    // ... Compra de productos
    public class PurchaseProduct
    {
        public int Id { get; set; }
        [Display(Name = "Fecha de compra")]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Proveedor")]
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        [Display(Name = "Cantidad ")]
        public int Quantity { get; set; }

        [Display(Name = "Orden de Compra")]
        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
