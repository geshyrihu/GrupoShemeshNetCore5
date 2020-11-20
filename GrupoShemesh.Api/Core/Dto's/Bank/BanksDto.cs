using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Core
{
    public class BanksDto
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string shortName { get; set; }
        public string LargeName { get; set; }
    }
}
