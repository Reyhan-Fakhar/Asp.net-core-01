using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02.Domain.Models.Request;
using Project_02.Domain.ViewModels;

namespace Project_02.Domain.Interfaces
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task UpdateRequest(Request request);
        Task<List<RequestResultViewModel>> GetAllRequests();
        Task<Request> GetRequestById(long requestId);
        Task<RequestDetailsResultViewModel> GetRequestDetails(long requestId);
        Task<List<Request>> GetAllCustomerRequests(long customerId);
        Task<DtResult<RequestResultViewModel>> GetData(DtParameters dtParameters);
    }
}
