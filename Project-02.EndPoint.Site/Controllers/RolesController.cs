using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
using Project_02.Application.ViewModels;

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
            return View(_permissionService.GetAllRoles());
        }

        [HttpGet]
        public void Create()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermissions();
        }

        [HttpPost]
        public IActionResult Create(string roleName)
        {
            if (!ModelState.IsValid)
            {
                return View();
            } 
            var result = _permissionService.CreateRole(new RoleRequestViewModel()
            {
                RoleName = roleName
            });
            //_permissionService.AddPermissionsToRole(SelectedPermission, result);
            return Redirect($"Roles/Index/");
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
