using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuntasApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeetingSupervisionsController : ControllerBase
    {
        private readonly IGenericRepository<MeetingSupervision> _genericRepository;

        public MeetingSupervisionsController(IGenericRepository<MeetingSupervision> genericRepository)
        {
            _genericRepository = genericRepository;
        }

      
    }
}
