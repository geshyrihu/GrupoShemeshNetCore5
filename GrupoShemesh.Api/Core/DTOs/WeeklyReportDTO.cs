using Administration.Enum;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoShemesh.Api.Core.DTOs
{
    public class PanelDto
    {
        public int Customer { get; set; }
        public EStatus? Status { get; set; }
        public int? Responsible { get; set; }
        public int? Request { get; set; }
        public DateTime? RequestStart { get; set; }
        public DateTime? FinishedStart { get; set; }
        public DateTime? RequestEnd { get; set; }
        public DateTime? FinishedEnd { get; set; }
        public EPriority? Priority { get; set; }
        //public string TypeReport { get; set; }
    }

    public class WeeklyReportDTO
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
        public string ImgUploadBefore { get; set; }
        public string ImgUploadAfter { get; set; }
        public ApplicationUser User { get; set; }

    }
    public class WeeklyReportPDFDTO
    {

        public int Id { get; set; }
        public string PhotoPathBefore { get; set; }
        public string PhotoPathAfter { get; set; }
   
        public string Activity { get; set; }
        public string Observations { get; set; }
        public int ResponsibleAreaId { get; set; }
        public virtual ResponsibleArea ResponsibleArea{ get; set; }
     

    }
    public class WeeklyReportAddOrEditDTO
    {


        [Display(Name = "Fecha de Termino")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFinished { get; set; } = null;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateRequest { get; set; } = null;

        public string Activity { get; set; }
        public string Observations { get; set; }
        public EStatus? Status { get; set; }
        public EPriority? Priority { get; set; }
        public int CustomerId { get; set; }
        public int ResponsibleAreaId { get; set; }
        public int RequestId { get; set; }
        public IFormFile PhotoPathBefore { get; set; }
        public IFormFile PhotoPathAfter { get; set; }
        public string User { get; set; }
    }
}
