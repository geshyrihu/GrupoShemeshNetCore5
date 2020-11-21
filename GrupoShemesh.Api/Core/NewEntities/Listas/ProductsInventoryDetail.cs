using Administration.Enum;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... Detalle de inventario (Lista de productos de Inventario)
    public class ProductsInventoryDetail
    {
        public int Id { get; set; }

        [Display(Name = "Inventario de Productos")]
        public int ProductsInventoryId { get; set; }
        public virtual ProductsInventory ProductsInventory { get; set; }

        [Display(Name = "Producto")]
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Existencia")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Existence { get; set; }

        [Display(Name = "Unidad ")]
        public EMeasurementUnits MeasurementUnits { get; set; }

        [Display(Name = "Stok minimo")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double StockMin { get; set; }

        [Display(Name = "Stok Maximo")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double StockMax { get; set; }

        [Display(Name = "Requiere compra")]
        public bool RequiresPurchase
        {
            get
            {
                if (Existence <= StockMin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
