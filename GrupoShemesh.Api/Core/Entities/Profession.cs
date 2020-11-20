using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class Profession
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Profesión")]
        [MaxLength(50)]
        public string NameProfession { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [MaxLength(255, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string Description { get; set; }

    }
}
