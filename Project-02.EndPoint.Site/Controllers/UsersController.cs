using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_02.Application.Interfaces;
using Project_02.Application.Security;
using Project_02.Domain.ViewModels;

namespace Project_02.EndPoint.Site.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public UsersController(IUserService userService,
            IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [PermissionChecker(7)]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        [PermissionChecker(8)]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _userService.CreateUser(model);
            if (result.IsSuccess) return RedirectToAction("Index");
            ModelState.AddModelError("", result.Message);
            return View(model); 
        }

        [HttpGet]
        [PermissionChecker(9)]
        public async Task<IActionResult> Edit(long userId)
        {
            var user = await _userService.GetUserByIdViewModel(userId);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _userService.UpdateUser(model, model.UserId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [PermissionChecker(10)]
        public async Task<IActionResult> Delete(long userId)
        {
            await _userService.DeleteUser(userId);
            return Json(new { isSuccess = true});
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatues(long userId)
        {
            await _userService.ChangeStatuesUser(userId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails(long userId)
        {
            var userDetails = await _userService.GetUserDetails(userId);

            var userRole = await _permissionService.GetRoleById(userDetails.RoleId);
            var userPermissions = await _permissionService.GetRoleDetails(userDetails.RoleId);

            return Json(new
            {
                userName = userDetails.UserName,
                roleName = userRole.RoleName,
                phoneNumber = userDetails.PhoneNumber,
                isActive = userDetails.IsActive,
                createDate = userDetails.CreateDate,
                permissionsName = userPermissions.PermissionsName,
            });
        }
    }
}
