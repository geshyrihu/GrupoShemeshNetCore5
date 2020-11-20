using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Entities
{
    public class DirectoryCondominium
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Departamento")]
        public string Department { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Torre")]
        public string Tower { get; set; }

        public virtual List<ListCondomino> ListCondominos { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Departamento")]
        public string FullName => $"{Department} {Tower}";


    }
}
