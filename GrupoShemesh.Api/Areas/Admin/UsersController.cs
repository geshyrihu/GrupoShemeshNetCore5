using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Core.DTOs.User;
using GrupoShemesh.Entities;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GrupoShemesh.Api.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseUrl _baseUrl;
        private readonly IImgService _imgService;

        public UsersController(IUserRepository userRepository,
                               IBaseUrl baseUrl,
                               IImgService imgService)
        {
            _userRepository = userRepository;
            _baseUrl = baseUrl;
            _imgService = imgService;
        }

        [HttpGet("GetDataUser/{id}")]
        public async Task<ActionResult<GetUserDto>> GetAsync(string id)
        {
            return await _userRepository.AccountUpdateInfoDto(id);
        }

        [HttpPut("UpdateDataUser/{id}")]
        public async Task<ActionResult<GetUserDto>> UpdateDataUser(string id, GetUserDto dto)
        {
            return await _userRepository.UpdateDataUser(id, dto);
        }

        [HttpPut("ChangePassword/{id}")]
        public async Task<ActionResult> ChangePassword(string id, ChangePasswordDto dto)
        {
            bool result = await _userRepository.ChangePassword(id, dto);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("updateImg/{id}")]
        public async Task<ActionResult<ApplicationUser>> UpdateImg(string id, [FromForm] IFormFile file)
        {

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                string arrayPath = ("img/Administration/accounts/");
                var fullPath = _baseUrl.GetBaseUrl(arrayPath);
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                if (file != null)
                {
                    if (user.PhotoPath != "avatar")
                    {
                        await _imgService.DeleteFile(fullPath, user.PhotoPath);
                    }
                    user.PhotoPath = _imgService.SaveFile(file, fullPath, 600, 600);

                    await _userRepository.UpdateImg(user);
                    var pathFile = new ImgPathFile();
                    pathFile.pathFile = user.PhotoPath;

                    return Ok(pathFile);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}
