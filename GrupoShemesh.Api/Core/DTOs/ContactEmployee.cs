using Administration.Enum;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class ContactEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ERelationEmployee? Relacion { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneOne { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneTwo { get; set; }
        public int EmployeeId { get; set; }
    }
    public class ContactEmployeeAddOrEditDTO
    {
        public string Name { get; set; }
        public ERelationEmployee? Relacion { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneOne { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneTwo { get; set; }
        public int EmployeeId { get; set; }
    }
}
