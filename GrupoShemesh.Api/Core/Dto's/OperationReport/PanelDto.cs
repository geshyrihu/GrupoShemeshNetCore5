using Administration.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoShemesh.Core.DTOs
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
        public string TypeReport { get; set; }
    }
}
