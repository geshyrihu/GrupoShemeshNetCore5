using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Core.DTOs.User;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Infrastructure.Services
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserById(string id);
        Task<ApplicationUser> UpdateImg(ApplicationUser user);
        Task<bool> ChangePassword(string id, ChangePasswordDto dto);
        Task<GetUserDto> AccountUpdateInfoDto(string id);
        Task<GetUserDto> UpdateDataUser(string id, GetUserDto dto);
    }

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetUserDto> AccountUpdateInfoDto(string id)
        {
            return await _userManager.Users.Select(x => new GetUserDto
            {
                Id = x.Id,
                Birth = x.Birth,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ChangePassword(string id, ChangePasswordDto dto)
        {
            var result = true;
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                result= false;
            }
            var resultOperation = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (!resultOperation.Succeeded)
            {
                result = false;
            }
            return result;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<GetUserDto> UpdateDataUser(string id, GetUserDto dto)
        {
            var entity = await _userManager.FindByIdAsync(id);

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Birth = dto.Birth;
            entity.Email = dto.Email;

            await _userManager.UpdateAsync(entity);
            return await AccountUpdateInfoDto(entity.Id);
        }

        public async  Task<ApplicationUser> UpdateImg(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
            return await GetUserById(user.Id);
        }
    }
}
