using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
using Project_02.Application.Security;
using Project_02.Domain.ViewModels;

namespace Project_02.EndPoint.Site.Controllers
{
    public class RolesController : Controller
    {
        private readonly IPermissionService _permissionService;
        private readonly IUserService _userService;

        public RolesController(IPermissionService permissionService, IUserService userService)
        {
            _permissionService = permissionService;
            _userService = userService;
        }

        [PermissionChecker(2)]
        public async Task<IActionResult> Index()
        {
            var roles = await _permissionService.GetAllRoles();
            return View(roles);
        }

        [HttpGet]
        [PermissionChecker(3)]
        public async Task<IActionResult> Create()
        {
            var permissions = await _permissionService.GetAllPermissions();
            ViewBag.Permissions = permissions;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateRequestViewModel model, List<long> selectedPermissions)
        {
            if (!ModelState.IsValid)
            {
                var permissions = await _permissionService.GetAllPermissions();
                ViewBag.Permissions = permissions;
                return View(model);
            }
            var roleId = await _permissionService.CreateRole(model);
            if (roleId == 0)
            {
                ModelState.AddModelError("RoleName", "نام نقش وارد شده تکراری است و قبلاً ثبت شده است.");
                ViewBag.ErrorMessage = "نام نقش وارد شده تکراری است و نمی‌توان آن را دوباره ثبت کرد.";

                return View(model);
            }

            await _permissionService.AddPermissionsToRole(selectedPermissions, roleId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [PermissionChecker(4)]
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditRequestViewModel model, long roleId, List<long> selectedPermissions)
        {
            await _permissionService.EditPermissionsRole(selectedPermissions, roleId);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [PermissionChecker(5)]
        public async Task<IActionResult> Delete(long roleId)
        {
            var user = await _userService.GetUsersByRoleId(roleId);

            if (user.Count > 0)
            {
                return Json(new { success = false, message = "این نقش به کاربران دیگری اختصاص داده شده است و نمی‌توان آن را حذف کرد." });
            }
            
            await _permissionService.DeleteRole(roleId);
            return Json(new { success = true });
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
