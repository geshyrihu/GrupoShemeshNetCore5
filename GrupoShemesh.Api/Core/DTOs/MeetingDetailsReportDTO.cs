using Administration.Enum;
using GrupoShemesh.Entities;
using System;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class MeetingDetailsReportDTO
    {
        public int Id { get; set; }
        public int ResponsibleAreaId { get; set; }
        public virtual ResponsibleArea ResponsibleArea { get; set; }
        public EStatus? Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Advance { get; set; }
        public string Title { get; set; }
        public string RequestService { get; set; }
        public string Observations { get; set; }
        public int MeetingId { get; set; }


    }
}
