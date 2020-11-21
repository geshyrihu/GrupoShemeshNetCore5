using AutoMapper;
using GrupoShemesh.Api.Core.DTOs;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Shopping
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IGenericRepository<PaymentMethod> _genericRepository;
        private readonly IMapper _mapper;

        public PaymentMethodsController(IGenericRepository<PaymentMethod> genericRepository,
                                        IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PaymentMethodDTO[]>> GetPaymentMethods()
        {
            var data = await _genericRepository.GetAsyncAll(null, x => x.OrderBy(x => x.Description), "");
            return _mapper.Map<PaymentMethodDTO[]>(data);
        }

        [HttpGet("{id}", Name = "GetPaymentMethod")]
        public async Task<ActionResult<PaymentMethodDTO>> GetPaymentMethod(int id)
        {
            var model = await _genericRepository.GetAsyncById(id);
            var dto = _mapper.Map<PaymentMethodDTO>(model);
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentMethodAddOrEitDTO>> Post(PaymentMethodAddOrEitDTO dto)
        {
            var model = _mapper.Map<PaymentMethod>(dto);
            var entity = await _genericRepository.CreateAsync(model);
            return new CreatedAtRouteResult("GetPaymentMethod", new { id = entity.Id }, entity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, PaymentMethodAddOrEitDTO dto)
        {
            var model = _mapper.Map<PaymentMethod>(dto);
            model.Id = id;
            await _genericRepository.UpdateAsync(model);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
