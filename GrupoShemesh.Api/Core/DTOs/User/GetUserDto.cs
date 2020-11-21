using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Core.DTOs
{
    public class GetUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
