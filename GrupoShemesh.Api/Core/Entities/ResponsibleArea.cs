using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class ResponsibleArea
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Area Responsable ")]
        [MaxLength(50, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string NameArea { get; set; }

    }
}
