using Project_02.Application.Interfaces;
using Project_02.Application.ViewModels;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;

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
        public long CreateRole(RoleRequestViewModel request)
        {
            var newRole = new Role()
            {
                RoleName = request.RoleName,
                InsertTime = DateTime.Now
            };
            _permissionRepository.AddRole(newRole);
            return newRole.RoleId;
        }
        public async Task DeleteRole(long roleId)
        {
            var role = await _permissionRepository.GetRoleById(roleId);
            role.IsRemoved = true;
            role.RemoveTime = DateTime.Now;
            await _permissionRepository.UpdateRole(role);
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _permissionRepository.GetAllRoles();
        }
        #endregion

        #region Permission
        public async Task AddPermissionsToRole(List<long> permissionIds, long roleId)
        {
            foreach (long permissionId in permissionIds)
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return await _permissionRepository.GetAllPermission();
        }
        #endregion
    }
}
