using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    // ... productos
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string NameProduct { get; set; }

        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Img")]
        public string PhotoPath { get; set; }

        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Usuario")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
