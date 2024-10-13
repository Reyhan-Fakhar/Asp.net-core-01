using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface IPermissionService
    {
        #region Roles
        Task<long> CreateRole(RoleRequestViewModel request);
        Task DeleteRole(long roleId);
        Task<IEnumerable<Role>> GetAllRoles();
        Task<DtResult<RoleResultViewModel>> GetData(DtParameters dtParameters);
        #endregion

        #region Permission
        Task AddPermissionsToRole(List<long> permissionIds, long roleId);
        Task EditPermissionsRole(List<long> permissionIds, long roleId);
        bool CheckPermission(long permissionId, string userName);
        Task<IEnumerable<Permission>> GetAllPermissions();
        
        #endregion
    }
}
