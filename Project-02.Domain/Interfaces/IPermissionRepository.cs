using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;

namespace Project_02.Domain.Interfaces
{
    public interface IPermissionRepository
    {
        #region Roles
        Task AddRole(Role role);
        Task UpdateRole(Role role);
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(long roleId);
        #endregion

        #region Permission
        Task AddPermissionToRole(long permissionId, long roleId);
        Task DeletePermissionFromRole(long roleId);
        //bool CheckPermission(long permissionId, string userName);
        Task<IEnumerable<Permission>> GetAllPermission();
        Task<List<long>> GetPermissionByRole(long roleId);
        #endregion
    }
}
