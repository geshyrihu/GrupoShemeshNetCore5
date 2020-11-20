using Administration.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace GrupoShemesh.Core.DTOs
{
    public class ToolDto
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public string User { get; set; }
        public int CustomerId { get; set; }
        public string NameTool { get; set; }
        public string Brand { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public EState State { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string TechnicalSpecifications { get; set; }
        public string Observations { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Img { get; set; }
    }
}
