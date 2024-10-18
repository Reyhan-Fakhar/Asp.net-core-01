using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Domain.Interfaces
{
    public interface IPermissionRepository
    {
        #region Roles
        Task<long> AddRole(Role role);
        Task UpdateRole(Role role);
        Task<List<RoleResultViewModel>> GetAllRoles();
        Task<Role> GetRoleById(long roleId);
        public bool IsExistRoleName(string roleName);
        Task<RoleDetailsResultViewModel> GetRoleDetails(long roleId);
        Task<long> GetUserRole(string userName);
        #endregion

        #region Permission
        Task AddPermissionToRole(long permissionId, long roleId);
        Task DeletePermissionFromRole(long roleId);
        //bool CheckPermission(long permissionId, string userName);
        Task<IEnumerable<Permission>> GetAllPermission();
        Task<List<Permission>> GetAllRolePermissions(long roleId);
        #endregion
    }
}
