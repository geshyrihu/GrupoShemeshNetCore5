using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{

    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Nombre de Categoría")]
        [MinLength(3, ErrorMessage = "{0} puede tener un minimo de {1} caracteres")]
        [MaxLength(20, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string NameCotegory { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
