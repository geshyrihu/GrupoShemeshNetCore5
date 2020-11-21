using Administration.Enum;
using GrupoShemesh.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Api.Core
{
    public class MettingetailsDto
    {
        public int Id { get; set; }
        public int ResponsibleAreaId { get; set; }
        public virtual ResponsibleArea ResponsibleArea { get; set; }
        public EStatus? Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public  DateTime DeliveryDate { get; set; }
        public int Advance { get; set; }
        public string Title { get; set; }
        public string RequestService { get; set; }
        public string Observations { get; set; }
        public int MeetingId { get; set; }
    }
}
