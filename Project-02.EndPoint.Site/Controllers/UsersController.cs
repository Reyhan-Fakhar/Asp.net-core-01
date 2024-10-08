using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
using Project_02.Application.ViewModels;

namespace Project_02.EndPoint.Site.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        [HttpGet]
        public void Create()
        {
            ViewData["Roles"] = _permissionService.GetAllRoles();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.CreateUser(viewModel);
            return Redirect("/users");
        }

        [HttpGet]
        public void Edit()
        {
            ViewData["Roles"] = _permissionService.GetAllRoles();
        }

        [HttpPost]
        public IActionResult Edit(UserRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _userService.EditUser(viewModel);
            return Redirect("/users");
        }

        [HttpPost]
        public IActionResult Delete(long userId)
        {
            ViewData["userId"] = userId;
            _userService.DeleteUser(userId);
            return View();
        }

        public Task<ActionResult> Show()
        {
            return Task.FromResult<ActionResult>(View());
        }

        [HttpPost]
        public IActionResult ChangeStatues(long userId)
        {
            return Json(_userService.ChangeStatuesUser(userId));
        }

    }
}
