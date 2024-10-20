﻿using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
using Project_02.Application.Security;
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
        [PermissionChecker(12)]
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
        [PermissionChecker(13)]
        public async Task<IActionResult> Create(CustomerCreateRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _customerService.CreateCustomer(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [PermissionChecker(14)]
        public async Task<IActionResult> Edit(long customerId)
        {
            ViewBag.CustomerId = customerId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditRequestViewModel model, long customerId)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CustomerId = customerId;
                return View(model);
            }
            await _customerService.EditCustomer(model, customerId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [PermissionChecker(15)]
        public async Task<IActionResult> Delete(long customerId)
        {
            await _customerService.DeleteCustomer(customerId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(long customerId)
        {
            var customer = await _customerService.GetCustomerDetails(customerId);

            return View(customer);
        }
    }
}
