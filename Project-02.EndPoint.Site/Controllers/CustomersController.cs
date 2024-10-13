using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
using Project_02.Domain.ViewModels;

namespace Project_02.EndPoint.Site.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        //public async Task<IActionResult> Index()
        //{
        //    //var customers = await _customerService.GetAllCustomers();
        //    //return View(customers);
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.CreateCustomer(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(long id)
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.EditCustomer(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            await _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

    }
}
