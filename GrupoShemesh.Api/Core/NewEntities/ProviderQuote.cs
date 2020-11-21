using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Cotización de Proveedor
    public class ProviderQuote
    {
        public int Id { get; set; }

        // ... Detalle de produstos de solicitud de compra
        [Display(Name ="Producto ")]
        public int PurchaseRequestDetailId { get; set; }
        public PurchaseRequestDetail PurchaseRequestDetail { get; set; }

        [Display(Name = "Proveedor")]
        public int providerId { get; set; }
        public virtual Provider Provider { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double Price { get; set; }

        [Display(Name = "Descuento")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double Discount { get; set; }

        [Display(Name = "Iva Aplicado")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double IvaApplied { get; set; } = .16;

        [Display(Name = "SubTotal")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double SubTotal { get; set; } = .16;

        [Display(Name = "Iva")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double Iva { get; set; } = .16;

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double Total { get; set; } = .16;

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
