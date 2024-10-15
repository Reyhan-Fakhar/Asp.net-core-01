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
        public async Task<long> CreateRole(RoleRequestViewModel request)
        {
            var newRole = new Role()
            {
                RoleName = request.RoleName,
            };
            return await _permissionRepository.AddRole(newRole); 
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

        public async Task<DtResult<RoleResultViewModel>> GetData(DtParameters dtParameters)
        {
            var result = await _permissionRepository.GetData(dtParameters);

            var row = dtParameters.Start + 1;

            foreach (var model in result.Data)
            {
                model.Row = row;
                row++;

                model.Operation =
                    $"<div class=\"dropdown d-inline-block\">" +
                    "<a class=\"nav-link dropdown-toggle arrow-none\" id=\"dLabel6\" data-toggle=\"dropdown\" href=\"#\" role=\"button\" aria-haspopup=\"false\" aria-expanded=\"false\">" +
                    "<i class=\"fas fa-ellipsis-v font-20 text-muted\"></i>" +
                    "</a>" +
                    "<div class=\"dropdown-menu\" aria-labelledby=\"dLabel6\">";

                model.Operation +=
                    $"<a class=\"dropdown-item\" href=\"/User/Edit/{model.RoleId}\">" +
                    "<i class=\"dripicons-pencil\"></i> ویرایش" +
                    "</a>";

                model.Operation += $"<a class=\"dropdown-item\" onclick=\"DeleteRole({model.RoleId})\">" +
                                   "<i class=\"dripicons-trash\"></i> حذف" +
                                   "</a>";

                model.Operation += " </div> </div>";
            }
            return result;
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
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            return await _permissionRepository.GetAllPermission();
        }
        #endregion
    }
}
