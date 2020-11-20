using Administration.Enum;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class ListCondomino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Habitante")]
        public EHabitant? Habitant { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nombre de condómino")]
        public string NameDirectoryCondominium { get; set; }

        [Display(Name = "Extensión")]
        public string Extencion { get; set; }

        [Display(Name = "Télefono Fijo")]
        [DataType(DataType.PhoneNumber)]
        public string FixedPhone { get; set; }

        [Display(Name = "Télefono celular")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress)]
        public string mail { get; set; }

        [Display(Name = "Departamento")]
        public int DirectoryCondominiumId { get; set; }
        public virtual DirectoryCondominium DirectoryCondominium { get; set; }
    }
}
