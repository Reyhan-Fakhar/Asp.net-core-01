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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllRole([FromBody] DtParameters dtParameters)
        {
            var dtResult = await _permissionService.GetData(dtParameters);

            return Json(dtResult);
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var permissions = await _permissionService.GetAllPermissions();
            ViewBag.Permissions = permissions;

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
