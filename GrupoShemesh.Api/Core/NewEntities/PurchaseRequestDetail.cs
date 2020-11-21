using Administration.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Detalle de produstos de solicitud de compra
    public class PurchaseRequestDetail
    {
        public int Id { get; set; }

        [Display(Name = "Solicitud de Compra")]
        public int PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; }

        [Display(Name = "Producto")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Cantidad")]
        public double Quantity { get; set; }

        [Display(Name = "Unidad ")]
        public EMeasurementUnits MeasurementUnits { get; set; }

        public virtual List<ProviderQuote> ProviderQuote { get; set; }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
