using Microsoft.EntityFrameworkCore;
using Project_02.Application.Interfaces;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        #region Role
        public async Task<long> CreateRole(RoleCreateRequestViewModel createRequest)
        {
            var newRole = new Role()
            {
                RoleId = createRequest.RoleId,
                RoleName = createRequest.RoleName,
            };

            return _permissionRepository.IsExistRoleName(newRole.RoleName)
                ? 0
                : await _permissionRepository.AddRole(newRole);
        }
        public async Task DeleteRole(long roleId)
        {
            var role = await _permissionRepository.GetRoleById(roleId);
            role.IsRemoved = true;
            role.RemoveTime = DateTime.Now;
            await _permissionRepository.UpdateRole(role);
        }
        public async Task<Role> GetRoleById(long roleId)
        {
            return await _permissionRepository.GetRoleById(roleId);
        }
        public async Task<List<RoleResultViewModel>> GetAllRoles()
        {
            return await _permissionRepository.GetAllRoles();
        }
        public async Task<RoleDetailsResultViewModel> GetRoleDetails(long roleId)
        {
            return await _permissionRepository.GetRoleDetails(roleId);
        }
        #endregion

        #region Permission
        public async Task AddPermissionsToRole(List<long> permissionIds, long roleId)
        {
            foreach (var permissionId in permissionIds)
            {
                await _permissionRepository.AddPermissionToRole(permissionId, roleId);
            }
        }
        public async Task EditPermissionsRole(List<long> permissionIds, long roleId)
        {
            await _permissionRepository.DeletePermissionFromRole(roleId);
            await AddPermissionsToRole(permissionIds, roleId);
        }
        public bool CheckPermission(long permissionId, string userName)
        {
            var userRoleId =  _permissionRepository.GetUserRole(userName).Result;
            var rolePermissions =  _permissionRepository
                .GetAllRolePermissions(userRoleId)
                .Result
                .Select(x => x.PermissionId)
                .ToList();
            return rolePermissions.Any(_ => rolePermissions.Contains(permissionId));
        }
        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return await _permissionRepository.GetAllPermission();
        }
        #endregion
    }
}
