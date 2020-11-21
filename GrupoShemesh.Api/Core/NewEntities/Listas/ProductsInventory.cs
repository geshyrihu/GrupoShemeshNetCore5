using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Inventario de productos por Edificios
    public class ProductsInventory
    {
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        // ...Lista de productos del inventario
        public virtual List<ProductsInventoryDetail> ProductsInventoryDetails { get; set; }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
