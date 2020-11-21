using Administration.Enum;
using System;

namespace GrupoShemesh.Core.DTOs
{
    public class MeetingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ETypeMeeting? ETypeMeeting { get; set; }
        public int CustomerId { get; set; }

    }
}
