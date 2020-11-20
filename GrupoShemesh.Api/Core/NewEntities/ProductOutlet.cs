using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class ProductOutlet
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Fecha de Salida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOutlet { get; set; } = null;

        [Display(Name = "Cantidad ")]
        public int Quantity { get; set; }
        [Display(Name = "Uso del producto")]
        public string Use { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
