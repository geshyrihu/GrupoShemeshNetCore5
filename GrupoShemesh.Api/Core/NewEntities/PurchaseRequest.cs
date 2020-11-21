using Administration.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Solicitud de Compra 
    public class PurchaseRequest
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOutlet { get; set; }

        [Display(Name = "Solicita")]
        public string Request { get; set; }

        [Display(Name = "Área equipo o instalación")]
        public string EquipmentOrInstallationArea { get; set; }

        [Display(Name = "Justificación del Gasto")]
        public string ExpenditureJustification { get; set; }

        [Display(Name = "Status")]
        public EStatus Estatus { get; set; }

        public virtual List<PurchaseRequestDetail> PurchaseRequestDetails { get; set; }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
