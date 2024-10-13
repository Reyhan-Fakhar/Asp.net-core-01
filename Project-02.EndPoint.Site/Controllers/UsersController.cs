using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_02.Application.Interfaces;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;
using System.Data;

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

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllUser([FromBody] DtParameters dtParameters)
        {
            var dtResult = await _userService.GetData(dtParameters);

            return Json(dtResult);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // ارسال اطلاعات دسترسی‌ها به View
            var roles = await _permissionService.GetAllRoles();
            ViewBag.Roles = new SelectList(roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRequestViewModel model)
        {
            await _userService.CreateUser(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            // ارسال اطلاعات دسترسی‌ها به View
            var roles = await _permissionService.GetAllRoles();
            ViewBag.Roles = new SelectList(roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserRequestViewModel model, long userId)
        {
            await _userService.EditUser(model, userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long userId)
        {
            await _userService.DeleteUser(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatues(long userId)
        {
            await _userService.ChangeStatuesUser(userId);
            return RedirectToAction("Index");
        }
    }
}
