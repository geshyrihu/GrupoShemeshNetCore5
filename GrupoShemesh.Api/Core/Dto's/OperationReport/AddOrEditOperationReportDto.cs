using Administration.Enum;
using Microsoft.AspNetCore.Http;
using System;

namespace GrupoShemesh.Core.DTOs
{
    public class AddOrEditOperationReportDto
    {

        public int Id { get; set; }
        public string PhotoPathBefore { get; set; }
        public string PhotoPathAfter { get; set; }
        public DateTime? DateFinished { get; set; } = null;
        public DateTime? DateRequest { get; set; } = null;
        public string Activity { get; set; }
        public string Observations { get; set; }
        public EStatus? Status { get; set; }
        public EPriority? Priority { get; set; }
        public int CustomerId { get; set; }
        public int ResponsibleAreaId { get; set; }
        public int RequestId { get; set; }
        public IFormFile ImgUploadBefore { get; set; }
        public IFormFile ImgUploadAfter { get; set; }
        public string User { get; set; }

    }
}
