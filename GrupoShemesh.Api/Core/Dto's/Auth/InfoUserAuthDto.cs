using System.Collections.Generic;

namespace GrupoShemesh.Core.DTOs.Auth
{
    public class InfoUserAuthDto
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birth { get; set; }
        public string PhotoPath { get; set; }
        public string Profession { get; set; }
        public string Customer { get; set; }
        public int CustomerId { get; set; }
        public IList<string> Roles { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public InfoUserAuthDto(string Id, string Phone, string Email, string FirstName,
                               string LastName, string Birth, string PhotoPath,
                               string Profession, string Customer, int CustomerId, IList<string> Roles)
        {
            this.Id = Id;
            this.Phone = Phone;
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Birth = Birth;
            this.PhotoPath = PhotoPath;
            this.Profession = Profession;
            this.Customer = Customer;
            this.CustomerId = CustomerId;
            this.Roles = Roles;
        }

    }
}
