using Project_02.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Request;
using Project_02.Domain.ViewModels;
using Project_02.Application.Convertor;

namespace Project_02.Application.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task CreateRequest(RequestCreateRequestViewModel requestCreateRequestViewModel)
        {
            var newRequest = new Request
            {
                CustomerId = requestCreateRequestViewModel.CustomerId,
                Date = requestCreateRequestViewModel.Date.ToGregorian(),
                Description = requestCreateRequestViewModel.Description,
            };
            await _requestRepository.AddRequest(newRequest);
        }
        public async Task EditRequest(RequestEditRequestViewModel editRequest, long requestId)
        {
            var newRequest = await _requestRepository.GetRequestById(requestId);
            newRequest.CustomerId = editRequest.CustomerId;
            newRequest.Date = editRequest.Date.ToGregorian();
            newRequest.Description = editRequest.Description;
            newRequest.InsertTime = DateTime.Now;

            await _requestRepository.UpdateRequest(newRequest);
        }
        public async Task DeleteRequest(long requestId)
        {
            var request = await _requestRepository.GetRequestById(requestId);
            request.IsRemoved = true;
            request.RemoveTime = DateTime.Now;
            await _requestRepository.UpdateRequest(request);
        }

        public async Task<RequestEditRequestViewModel> GetRequestByIdViewModel(long requestId)
        {
            var request = await _requestRepository.GetRequestById(requestId);
            return new RequestEditRequestViewModel()
            {
                RequestId = requestId,
                CustomerId = request.CustomerId,
                //Date = request.Date.ToShamsi(),
                Description = request.Description,
            };
        }
        public async Task<List<RequestResultViewModel>> GetAllRequests()
        {
            return await _requestRepository.GetAllRequests();
        }
        public async Task<RequestDetailsResultViewModel> GetRequestDetail(long requestId)
        {
            return await _requestRepository.GetRequestDetails(requestId);
        }
        public async Task<DtResult<RequestResultViewModel>> GetData(DtParameters dtParameters)
        {

            var result = await _requestRepository.GetData(dtParameters);

            var row = dtParameters.Start + 1;

            foreach (var model in result.Data)
            {
                model.Row = row;
                row++;


                model.Operation =
                    $"<div class=\"dropdown d-inline-block\">" +
                    "<a class=\"nav-link dropdown-toggle arrow-none\" id=\"dLabel6\" data-toggle=\"dropdown\" href=\"#\" role=\"button\" aria-haspopup=\"false\" aria-expanded=\"false\">" +
                    "<i class=\"fas fa-ellipsis-v font-20 text-muted\"></i>" +
                    "</a>" +
                    "<div class=\"dropdown-menu\" aria-labelledby=\"dLabel6\">";



                model.Operation +=
                    $"<a class=\"dropdown-item\" href=\"/Requests/Edit/{model.RequestId}\">" +
                    "<i class=\"dripicons-pencil\"></i> ویرایش" +
                    "</a>";


                model.Operation += $"<a class=\"dropdown-item\" onclick=\"Delete({model.RequestId})\">" +
                                   "<i class=\"dripicons-trash\"></i> حذف" +
                                   "</a>";


                model.Operation += " </div> </div>";
            }

            return result;
        }
    }
}
