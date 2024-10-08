using Microsoft.EntityFrameworkCore;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;
using Project_02.Infrastructure.Data.Context;

namespace Project_02.Infrastructure.Data.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DataBaseContext _context;

        public PermissionRepository(DataBaseContext context)
        {
            _context = context;
        }

        #region Role
        public async Task AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleById(long roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }
        #endregion

        #region Permission

        public async Task AddPermissionToRole(long permissionId, long roleId)
        {
            await _context.RolePermission.AddAsync(new RolePermission()
            {
                PermissionId = permissionId,
                RoleId = roleId
            });
            await _context.SaveChangesAsync();
        }

        public async Task DeletePermissionFromRole(long roleId)
        {
            _context.RolePermission.Where(r => r.RoleId == roleId)
                .ToList().ForEach(p => _context.RolePermission.Remove(p));
        }

        public async Task<IEnumerable<Permission>> GetAllPermission()
        {
            return await _context.Permission.ToListAsync();
        }

        public async Task<List<long>> GetPermissionByRole(long roleId)
        {
            return await _context.RolePermission
                .Where(r => r.RoleId == roleId)
                .Select(p => p.PermissionId).ToListAsync();
        }
        #endregion

    }
}
