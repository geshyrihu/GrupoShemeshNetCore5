using Administration.Enum;
using System;

namespace GrupoShemesh.Core.DTOs
{
    public class MettingDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ETypeMeeting? ETypeMeeting { get; set; }
        public int CustomerId { get; set; }
        public string User { get; set; }
    }
}
