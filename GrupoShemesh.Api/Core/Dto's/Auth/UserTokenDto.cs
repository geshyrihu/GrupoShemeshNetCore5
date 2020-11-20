using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoShemesh.Core.DTOs.Auth
{
    public class UserTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public InfoUserAuthDto InfoUserAuthDto { set; get; }


    }
}
