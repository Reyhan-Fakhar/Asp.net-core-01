using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Project_02.Application.Interfaces;
using Project_02.Application.Security;
using Project_02.Domain.ViewModels;

namespace Project_02.EndPoint.Site.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly ICustomerService _customerService;

        public RequestsController(IRequestService requestService, ICustomerService customerService)
        {
            _requestService = requestService;
            _customerService = customerService;
        }

        [PermissionChecker(20)]
        public async Task<IActionResult> Index()
        {
            var requests = await _requestService.GetAllRequests();
            return View(requests);
        }

        [PermissionChecker(20)]
        public async Task<IActionResult> Report()
        {
            var requests = await _requestService.GetAllRequests();
            return View(requests);
        }

        public async Task<IActionResult> Index2()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllOrder([FromBody] DtParameters dtParameters)
        {
            try
            {
                var dtResult = await _requestService.GetData(dtParameters);
                return Json(dtResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // یا استفاده از ILogger برای ثبت لاگ
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        [PermissionChecker(17)]
        public async Task<IActionResult> Create()
        {
            return View(new RequestCreateRequestViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequestCreateRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _requestService.CreateRequest(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [PermissionChecker(18)]
        public async Task<IActionResult> Edit(long requestId)
        {
            var request = await _requestService.GetRequestByIdViewModel(requestId);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RequestEditRequestViewModel model, long requestId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _requestService.EditRequest(model, requestId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(long requestId)
        {
            var requestDetail = await _requestService.GetRequestDetail(requestId);
            return View(requestDetail);
        }

        [HttpPost]
        [PermissionChecker(19)]
        public async Task<IActionResult> Delete(long requestId)
        {
            await _requestService.DeleteRequest(requestId);
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerDetails(long customerId)
        {
            var customerDetails = await _customerService.GetCustomerDetails(customerId);

            return Json(new
            {
                customerName = customerDetails.FullName,
                province = customerDetails.Province,
                township = customerDetails.Township,
                phoneNumber = customerDetails.PhoneNumber,
                address = customerDetails.Address,
                description = customerDetails.Description,
                createDate = customerDetails.CreateDate,
            });
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

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            var requests = await _requestService.GetAllRequests();

            using var package = new XLWorkbook() { RightToLeft = true };
            var worksheet = package.Worksheets.Add("Requests");

            worksheet.Cell(1, 1).Value = "ردیف";
            worksheet.Cell(1, 2).Value = "نام مشتری";
            worksheet.Cell(1, 3).Value = "تاریخ";
            worksheet.Cell(1, 4).Value = "استان";
            worksheet.Cell(1, 5).Value = "شهرستان";
            worksheet.Cell(1, 6).Value = "توضیحات";

            var row = 2;
            for (var i = requests.Count -1; i >= 0 ; i--)
            {
                worksheet.Cell(row, 1).Value = row - 1;
                worksheet.Cell(row, 2).Value = requests[i].CustomerName;
                worksheet.Cell(row, 3).Value = requests[i].Date;
                worksheet.Cell(row, 4).Value = requests[i].Province;
                worksheet.Cell(row, 5).Value = requests[i].Township;
                worksheet.Cell(row, 6).Value = requests[i].Description;
                row++;
            }

            // ذخیره فایل اکسل در حافظه
            var stream = new MemoryStream();
            package.SaveAs(stream);
            stream.Position = 0;

            var fileName = $"Requests_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
