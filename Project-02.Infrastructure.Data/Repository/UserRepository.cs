using Microsoft.EntityFrameworkCore;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.User;
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
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(long userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        #endregion

        #region Role
        public async Task DeleteRoleFromUser(long userId)
        {
            _context.UserRoles.Where(r => r.UserId == userId)
                .ToList().ForEach(r => _context.UserRoles.Remove(r));
        }

        public Role GetRoleById(long roleId)
        {
            return  _context.Roles.Find(roleId);
        }
        #endregion
    }
}
