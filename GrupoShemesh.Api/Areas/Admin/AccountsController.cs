using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperUsuario")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountsController(IAccountRepository accountRepository,
                                  IAuthRepository authRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        [HttpGet("Search/{value}")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetSearch(string value)
        {
            var data = await _accountRepository.GetSearchAsync(value);
            return Ok(data);
        }

        [HttpGet("ToBlockAccount/{id}")]
        public void ToBlockAccountAsync(string id)
        {
            _accountRepository.ToBlockAccountAsync(id);
        }

        [HttpGet("ToUnlockAccount/{id}")]
        public void ToUnlockAccountAsync(string id)
        {
            _accountRepository.ToUnlockAccountAsync(id);
        }

        [HttpPut("UpdateCustomerAccount/{id}/{idCustomer}")]
        public ActionResult UpdateCustomerAccount(string id, int idCustomer)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                _accountRepository.UpdateCustomerAccount(id, idCustomer);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateProfessionAccount/{id}/{idProfession}")]
        public ActionResult UpdateProfessionAccount(string id, int idProfession)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                _accountRepository.UpdateProfessionAccount(id, idProfession);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _accountRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            var result = await _accountRepository.DeleteAsync(entity);
            if (result.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Error al intentar eliminar cuenta");
            }
        }

        [HttpGet("GetRole/{id}")]
        public async Task<ActionResult<List<AddRoleToUserDto>>> GetRoleAccount(string id)
        {
            return await _accountRepository.GetRoleAccount(id);
        }

        [HttpPost("AddRoleToUser/{id}")]
        public async Task<IActionResult> UpdateRoleToUser([FromBody] List<AddRoleToUserDto> model, string id)
        {
            ApplicationUser user = await _accountRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var resultAddRoleToUser = _accountRepository.AddRoleToUser(user, model);
            if (!resultAddRoleToUser.Result.Succeeded)
            {
                return NotFound("No se pueden eliminar los roles de usuario existentes");
            }
            var RemoveRoleToUser = _accountRepository.RemoveRoleToUser(user, model);

            if (!RemoveRoleToUser.Result.Succeeded)
            {
                return NotFound("No se pueden agregar roles seleccionados al usuario");
            }
            return NoContent();
        }
    }
}
