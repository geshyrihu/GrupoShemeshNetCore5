using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Nombre")]
        [MinLength(3, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        [MaxLength(30, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Apellidos")]
        [MinLength(3, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        [MaxLength(30, ErrorMessage = "{0} puede tener un máximo de {1} caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birth { get; set; }

        [Display(Name = "Usuario Activo")]
        public bool Active { get; set; } = true;

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Profesión")]
        public int ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [Display(Name = "Número de Télefono")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Formato no valido.")]
        public override string PhoneNumber { get; set; }

        [Display(Name = "Foto")]
        public string PhotoPath { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName => $"{FirstName} {LastName}";

    }
}
