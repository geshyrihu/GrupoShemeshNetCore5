﻿using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Orden de compra
    public class PurchaseOrder
    {
        public int Id { get; set; }

        [Display(Name = "Solicitud")]
        public int PurchaseRequestId { get; set; }
        public virtual PurchaseRequest PurchaseRequest { get; set; }


        [Display(Name = "Uso de Cfdi")]
        public int UseCFDIId { get; set; }
        public virtual UseCFDI UseCFDI { get; set; }


        [Display(Name = "Metodo de Pago")]
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }


        [Display(Name = "Forma de Pago")]
        public int WayToPayId { get; set; }
        public virtual WayToPay WayToPay { get; set; }


        [Display(Name = "Autoriza")]
        public string Authorize { get; set; }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
