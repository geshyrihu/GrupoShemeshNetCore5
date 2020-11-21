using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Http;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class ProviderDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string NameProvider { get; set; }
        public string Rfc { get; set; }
        public string Address { get; set; }
        public string PathPhoto { get; set; }
        public bool Sales { get; set; }
        public bool Repair { get; set; }
        public string phoneOne { get; set; }
        public string phoneTwo { get; set; }
        public string WebPage { get; set; }
        public string ContactOne { get; set; }
        public string PositionOne { get; set; }
        public string CellPhoneOne { get; set; }
        public string EmailOne { get; set; }
        public string ContactTwo { get; set; }
        public string PositionTwo { get; set; }
        public string CellPhoneTwo { get; set; }
        public string EmailTwo { get; set; }
        public string NameCheck { get; set; }
        public int BankId { get; set; }
        public virtual Bank bank { get; set; }
        public string PaymentAccount { get; set; }
        public string InterbankCode { get; set; }
    }

    public class ProviderAddOrEditDTO
    {
        public int CategoryId { get; set; }
        public string NameProvider { get; set; }
        public string Rfc { get; set; }
        public string Address { get; set; }
        public IFormFile PathPhoto { get; set; }
        public bool Sales { get; set; }
        public bool Repair { get; set; }
        public string phoneOne { get; set; }
        public string phoneTwo { get; set; }
        public string WebPage { get; set; }
        public string ContactOne { get; set; }
        public string PositionOne { get; set; }
        public string CellPhoneOne { get; set; }
        public string EmailOne { get; set; }
        public string ContactTwo { get; set; }
        public string PositionTwo { get; set; }
        public string CellPhoneTwo { get; set; }
        public string EmailTwo { get; set; }
        public string NameCheck { get; set; }
        public int BankId { get; set; }
        public string PaymentAccount { get; set; }
        public string InterbankCode { get; set; }
        public string User { get; set; }
    }
}
