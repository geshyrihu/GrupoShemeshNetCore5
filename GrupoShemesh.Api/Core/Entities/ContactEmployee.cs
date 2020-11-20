using Administration.Enum;
using System.ComponentModel.DataAnnotations;


namespace GrupoShemesh.Entities
{

    public class ContactEmployee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        public ERelationEmployee? Relacion { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneOne { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneTwo { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
