using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_02.Application.Interfaces;
using Project_02.Application.Services;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.EndPoint.Site.Controllers
{
    public class RolesController : Controller
    {
        private readonly IPermissionService _permissionService;

        public RolesController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _permissionService.GetAllRoles();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var permissions = await _permissionService.GetAllPermissions();
            ViewBag.Permissions = permissions;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleRequestViewModel model, List<long> selectedPermissions)
        {
            var roleId = await _permissionService.CreateRole(model);
            await _permissionService.AddPermissionsToRole(selectedPermissions, roleId);
            return RedirectToAction("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? roleId)
        {
            
            if (roleId.HasValue)
            {
                var selectedRoleId = roleId.Value;
                var role = _permissionService.GetRoleById(selectedRoleId);
                ViewBag.RoleId = selectedRoleId;
                ViewBag.RoleName = role.Result.RoleName;
            }

            var permissions = await _permissionService.GetAllPermissions();
            ViewBag.Permissions = permissions;

            var roles = await _permissionService.GetAllRoles();
            ViewBag.Roles = roles;
            
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(long roleId, List<long> selectedPermissions)
        {
            await _permissionService.EditPermissionsRole(selectedPermissions, roleId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long roleId)
        {
            await _permissionService.DeleteRole(roleId);
            return RedirectToAction("Index");
        }
    }
}
