using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
using Project_02.Application.Services;
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
        public async Task<IActionResult> Index()
        {
            var customer = await _customerService.GetAllCustomers();
            return View(customer);
        }
        public async Task<IActionResult> GetProvinces()
        {
            var provinces = await _customerService.GetAllProvinces(); 
            return Json(provinces);
        }

        public async Task<IActionResult> GetTownships(int provinceId)
        {
            var townships = await _customerService.GetTownshipsByProvinceId(provinceId); 
            return Json(townships);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestViewModel model)
        {
            await _customerService.CreateCustomer(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestViewModel model, long customerId)
        {

            await _customerService.EditCustomer(model, customerId);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(long customerId)
        {
            await _customerService.DeleteCustomer(customerId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(long customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);

            return View(customer);
        }

    }
}
