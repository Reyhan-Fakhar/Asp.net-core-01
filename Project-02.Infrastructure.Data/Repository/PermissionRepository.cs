using Microsoft.EntityFrameworkCore;
using Project_02.Application.Convertor;
using Project_02.Application.Helper;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;
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
        public async Task<long> AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.RoleId;
        }
        public async Task UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
        public async Task<List<RoleResultViewModel>> GetAllRoles()
        {
            return await _context.Roles
                .Select(role => new RoleResultViewModel
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    CreateDate = role.InsertTime.ToShamsi(),
                })
                .ToListAsync();
        }
        public async Task<Role> GetRoleById(long roleId)
        {
            return await _context.Roles
                .Include(x=> x.Users)
                .FirstOrDefaultAsync(x=> x.RoleId == roleId);
        }
        public bool IsExistRoleName(string roleName)
        {
            return _context.Roles.Any(r => r.RoleName == roleName);
        }
        public async Task<RoleDetailsResultViewModel> GetRoleDetails(long roleId)
        {
            var role = await GetRoleById(roleId);
            var permissions = await GetAllRolePermissions(roleId);


            var roleDetails = new RoleDetailsResultViewModel()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                CreateDate = role.InsertTime.ToShamsi(),

                PermissionsId = permissions.Select(p => p.PermissionId).ToList(),
                PermissionsName = permissions.Select(p => p.PermissionTitle).ToList()
            };
            return roleDetails;
        }
        public async Task<long> GetUserRole(string userName)
        { 
            return _context.Users.Single(u => u.UserName == userName).RoleId;
            
        }
        #endregion

        #region Permission
        public async Task AddPermissionToRole(long permissionId, long roleId)
        {
            var rolePermission = new RolePermission
            {
                PermissionId = permissionId,
                RoleId = roleId,
            };
            await _context.RolePermission.AddAsync(rolePermission);

            var role = await GetRoleById(roleId);
            role.UpdateTime = DateTime.Now;

            await _context.SaveChangesAsync();
        }
        public async Task DeletePermissionFromRole(long roleId)
        {
            var rolePermission = await _context.RolePermission.Where(r => r.RoleId == roleId).ToListAsync();
            _context.RolePermission.RemoveRange(rolePermission);

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Permission>> GetAllPermission()
        {
            return await _context.Permission.ToListAsync();
        }
        public async Task<List<Permission>> GetAllRolePermissions(long roleId)
        {
            var permissionIds = await _context.RolePermission
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            return await _context.Permission
                .Where(p => permissionIds.Contains(p.PermissionId))
                .ToListAsync();
        }
        #endregion

    }
}
