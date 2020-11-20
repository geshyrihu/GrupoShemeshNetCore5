using Administration.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Solicitud de Compra 
    public class PurchaseRequest
    {
        public int Id { get; set; }

        [Display(Name = "Solicita")]
        public string Request { get; set; }

        [Display(Name = "Área equipo o instalación")]
        public string EquipmentOrInstallationArea { get; set; }

        [Display(Name = "Justificación del Gasto")]
        public string ExpenditureJustification { get; set; }

        [Display(Name = "Status")]
        public EStatus Estatus { get; set; }

        public virtual List<Product> Products { get; set; }


        [Display(Name = "User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
