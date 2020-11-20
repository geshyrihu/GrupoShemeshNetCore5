using Administration.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Api.Core
{
    public class MettingetailsDto
    {
        public int Id { get; set; }
        public int ResponsibleAreaId { get; set; }
        public EStatus? Status { get; set; }
        public string DeliveryDate { get; set; }
        public int Advance { get; set; }
        public string Title { get; set; }
        public string RequestService { get; set; }
        public string Observations { get; set; }
        public int MeetingId { get; set; }
    }
}
