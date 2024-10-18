using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
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
        public async Task<IActionResult> Create(RoleCreateRequestViewModel model, List<long> selectedPermissions)
        {
            var roleId = await _permissionService.CreateRole(model);
            if (roleId == 0)
            {
                ModelState.AddModelError("RoleName", "نام نقش وارد شده تکراری است و قبلاً ثبت شده است.");
                ViewBag.ErrorMessage = "نام نقش وارد شده تکراری است و نمی‌توان آن را دوباره ثبت کرد.";

                return View(model);
            }

            await _permissionService.AddPermissionsToRole(selectedPermissions, roleId);
            return RedirectToAction("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? roleId)
        {
            if (roleId.HasValue)
            {
                var roleDetails = await _permissionService.GetRoleDetails(roleId.Value);
                var roleEditViewModel = new RoleEditRequestViewModel
                {
                    RoleId = roleDetails.RoleId,
                    RoleName = roleDetails.RoleName,
                    PermissionsName = roleDetails.PermissionsName
                };

                ViewBag.RoleId = roleId;
                ViewBag.Permissions = await _permissionService.GetAllPermissions();
                return View(roleEditViewModel);
            }

            ViewBag.Roles = await _permissionService.GetAllRoles();

            return View(new RoleEditRequestViewModel());
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

        [HttpGet]
        public async Task<IActionResult> GetRoleDetails(long roleId)
        {
            var roleDetails = await _permissionService.GetRoleDetails(roleId);

            return Json(new
            {
                roleName = roleDetails.RoleName,
                createDate = roleDetails.CreateDate,
                permissionsName = roleDetails.PermissionsName
            });
        }
    }
}
