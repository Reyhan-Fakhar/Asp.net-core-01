using Project_02.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Request;
using Project_02.Domain.ViewModels;

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
                Date = requestCreateRequestViewModel.Date,
                Description = requestCreateRequestViewModel.Description,
            };
            await _requestRepository.AddRequest(newRequest);
        }
        public async Task EditRequest(RequestEditRequestViewModel editRequest, long requestId)
        {
            var newRequest = await _requestRepository.GetRequestById(requestId);
            newRequest.CustomerId = editRequest.CustomerId;
            newRequest.Date = editRequest.Date;
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
        public async Task<List<RequestResultViewModel>> GetAllRequests()
        {
            return await _requestRepository.GetAllRequests();
        }
        public async Task<RequestDetailsResultViewModel> GetRequestDetail(long requestId)
        {
            return await _requestRepository.GetRequestDetails(requestId);
        }
    }
}
