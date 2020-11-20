using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrupoShemesh.Entities
{
    public class Committee
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Presidente")]
        public virtual ListCondomino President { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Tesoreso")]
        public virtual ListCondomino Treasurer { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Vocal")]
        public virtual List<ListCondomino> Vocals { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
