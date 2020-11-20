using GrupoShemesh.Core.DTOs;
using GrupoShemesh.Data;
using GrupoShemesh.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoShemesh.Infrastructure.Services
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetAsync(string id);
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<IdentityResult> AddRoleToUser(ApplicationUser user, List<AddRoleToUserDto> model);
        Task<IdentityResult> DeleteAsync(ApplicationUser entity);
        Task<IdentityResult> RemoveRoleToUser(ApplicationUser user, List<AddRoleToUserDto> model);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<IEnumerable<ApplicationUser>> GetSearchAsync(string value);
        Task<List<AddRoleToUserDto>> GetRoleAccount(string id);
        void ToBlockAccountAsync(string id);
        void ToUnlockAccountAsync(string id);
        void UpdateCustomerAccount(string id, int idCustomer);
        void UpdateProfessionAccount(string id, int idProfession);

    }
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(ApplicationDbContext db,
                                 RoleManager<IdentityRole> roleManager,
                                 UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetSearchAsync(string value)
        {
            return await _userManager.Users.Include(c => c.Customer)
                                              .Include(p => p.Profession)
                                              .Where(x => x.FirstName.Contains(value) ||
                                                          x.Email.Contains(value) ||
                                                          x.LastName.Contains(value) ||
                                                          x.Customer.NameCustomer.Contains(value) ||
                                                          x.Profession.NameProfession.Contains(value))
                                              .OrderBy(o => o.FirstName)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _userManager.Users.Include(X => X.Profession)
                                           .Include(x => x.Customer)
                                           .OrderBy(x => x.FirstName)
                                           .ToListAsync();
        }

        public async Task<ApplicationUser> GetAsync(string id)
        {
            return await _userManager.Users.Include(x => x.Customer)
                                           .Include(x => x.Profession)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<ApplicationUser> GetByIdAsync(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser entity)
        {
            return _userManager.DeleteAsync(entity);
        }

        public void ToBlockAccountAsync(string id)
        {
            var userDb = _userManager.FindByIdAsync(id);
            userDb.Result.LockoutEnd = DateTime.Now.AddYears(100);
            userDb.Result.Active = false;
            _db.SaveChanges();
        }

        public void ToUnlockAccountAsync(string id)
        {
            var userDb = _userManager.FindByIdAsync(id);
            userDb.Result.LockoutEnd = DateTime.Now;
            userDb.Result.Active = true;
            _db.SaveChanges();
        }

        public void UpdateCustomerAccount(string id, int idCustomer)
        {
            var userDb = _userManager.FindByIdAsync(id);
            userDb.Result.CustomerId = idCustomer;
            _db.SaveChanges();
        }

        public void UpdateProfessionAccount(string id, int idProfession)
        {
            var userDb = _userManager.FindByIdAsync(id);
            userDb.Result.ProfessionId = idProfession;
            _db.SaveChanges();
        }

        public async Task<List<AddRoleToUserDto>> GetRoleAccount(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (id == null)
            {
                return null;
            }
            List<AddRoleToUserDto> model = new List<AddRoleToUserDto>();
            foreach (IdentityRole role in _roleManager.Roles.ToList())
            {
                AddRoleToUserDto userRolesViewModel = new AddRoleToUserDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return model;
        }

        public async Task<IdentityResult> AddRoleToUser(ApplicationUser user, List<AddRoleToUserDto> model)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<IdentityResult> RemoveRoleToUser(ApplicationUser user, List<AddRoleToUserDto> model)
        {
            return await _userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));
        }
    }
}
