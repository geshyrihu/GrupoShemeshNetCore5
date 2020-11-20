using Administration.Enum;
using GrupoShemesh.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoShemesh.Core.DTOs
{
    public class MeetingsAllDto
    {
        public int Id { get; set; }
        public ETypeMeeting? ETypeMeeting { get; set; }
        public List<MeetingDetails> Issues { get; set; }
        public DateTime Date { get; set; }
        public List<MeetingDetails> Pending { get; set; }
        public int CustomerId { get; set; }
    }
}
