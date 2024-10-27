using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Project_02.Application.Interfaces;
using Project_02.Application.Security;
using Project_02.Application.Services;
using Project_02.Domain.Models.Customer;
using Project_02.Domain.ViewModels;
using Path = System.IO.Path;

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
            var customer = await _customerService.GetCustomerByIdViewModel(customerId);

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _customerService.EditCustomer(model, model.CustomerId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [PermissionChecker(15)]
        public async Task<IActionResult> Delete(long customerId)
        {
            await _customerService.DeleteCustomer(customerId);
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> Detail(long customerId)
        {
            var customer = await _customerService.GetCustomerDetails(customerId);

            return View(customer);
        }

        public IActionResult DownloadSampleExcel()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "File", "sample-file.xlsx");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sample-file.xlsx");
        }

        public IActionResult GenerateExcel()
        {
            using var workbook = new XLWorkbook() { RightToLeft = true };
            var worksheet = workbook.Worksheets.Add("Customers");

            worksheet.Cell(1, 1).Value = "نام مشتری";
            worksheet.Cell(1, 2).Value = "استان";
            worksheet.Cell(1, 3).Value = "شهر";
            worksheet.Cell(1, 4).Value = "شماره تلفن";
            worksheet.Cell(1, 5).Value = "آدرس";

            worksheet.Column(1).Width = 30;
            worksheet.Column(2).Width = 20;
            worksheet.Column(3).Width = 20;
            worksheet.Column(4).Width = 15;
            worksheet.Column(5).Width = 40;

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "create_customers.xlsx");
        }

        [HttpPost]

        public async Task<IActionResult> UploadExcel(IFormFile? excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ModelState.AddModelError("", "لطفا فایل اکسل را آپلود کنید");
                return RedirectToAction("Index");
            }

            var customers = new List<CustomerCreateRequestViewModel>();
            var errorMessages = new List<string>();
            var provinces = await _customerService.GetAllProvinces();

            using var stream = new MemoryStream();
            await excelFile.CopyToAsync(stream);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheet(1);
            var rowCount = worksheet.LastRowUsed()!.RowNumber();

            for (var row = 2; row <= rowCount; row++)
            {
                var provinceName = worksheet.Cell(row, 2).GetString();
                var townshipName = worksheet.Cell(row, 3).GetString();

                var province = provinces.FirstOrDefault(p => p.ProvinceName == provinceName);

                if (province == null)
                {
                    errorMessages.Add($"استان نامعتبر است : خطا در ردیف {row}");
                    continue;
                }

                var townships = await _customerService.GetTownshipsByProvinceId(province.ProvinceId);
                var township = townships.FirstOrDefault(t => t.TownshipName == townshipName);

                if (township == null)
                {
                    errorMessages.Add($"شهرستان نامعتبر است : خطا در ردیف {row}");
                    continue;
                }

                var customer = new CustomerCreateRequestViewModel
                {
                    FullName = worksheet.Cell(row, 1).GetString(),
                    ProvinceId = province.ProvinceId,
                    TownshipId = township.TownshipId,
                    PhoneNumber = worksheet.Cell(row, 4).GetString(),
                    Address = worksheet.Cell(row, 5).GetString(),
                    Description = "ندارد"
                };

                if (TryValidateModel(customer))
                {
                    customers.Add(customer);
                }
                else
                {
                    errorMessages.Add($"اطلاعات نامعتبر است : خطا در ردیف {row}");
                }
            }

            if (errorMessages.Any())
            {
                foreach (var errorMessage in errorMessages)
                {
                    ModelState.AddModelError("", errorMessage);
                }
            }

            foreach (var customer in customers)
            {
                await _customerService.CreateCustomer(customer);
            }

            var updateCustomer = await _customerService.GetAllCustomers();
            return View("Index", updateCustomer);
        }

    }
}
