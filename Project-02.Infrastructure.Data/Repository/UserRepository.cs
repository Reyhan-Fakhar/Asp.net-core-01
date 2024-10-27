using Microsoft.EntityFrameworkCore;
using Project_02.Application.Convertor;
using Project_02.Application.Helper;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;
using Project_02.Infrastructure.Data.Context;

namespace Project_02.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;
        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        #region User
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }
        public async Task<List<UserResultViewModel>> GetAllUsers()
        {
            return await _context.Users.Select(user => new UserResultViewModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FullName = user.FullName,
                UserRole = user.Role.RoleName,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                CreateDate = user.InsertTime.ToShamsi(),
            }).ToListAsync();
        }
        public async Task<User> GetUserById(long userId)
        {
            return await _context.Users
                .Include(x=>x.Role)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<List<User>> GetUsersByRoleId(long roleId)
        {
            return  await _context.Users
                .Include(x => x.Role)
                .Where(x => x.RoleId == roleId).ToListAsync();
        }
        public async Task<UserDetailsResultViewModel> GetUserDetails(long userId)
        {
            var user = await GetUserById(userId);

            var userDetails = new UserDetailsResultViewModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FullName = user.FullName,
                RoleId = user.RoleId,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive ? "فعال" : "غیرفعال",
                CreateDate = user.InsertTime.ToShamsi()
            };
            return userDetails;
        }
        #endregion
    }
}
