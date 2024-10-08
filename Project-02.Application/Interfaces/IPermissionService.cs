using Project_02.Application.ViewModels;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;

namespace Project_02.Application.Interfaces
{
    public interface IPermissionService
    {
        #region Roles
        long CreateRole(RoleRequestViewModel request);
        Task DeleteRole(long roleId);
        Task<IEnumerable<Role>> GetAllRoles();
        #endregion

        #region Permission
        Task AddPermissionsToRole(List<long> permissionIds, long roleId);
        Task EditPermissionsRole(List<long> permissionIds, long roleId);
        bool CheckPermission(long permissionId, string userName);
        Task<IEnumerable<Permission>> GetAllPermissions();
        #endregion
    }
}
