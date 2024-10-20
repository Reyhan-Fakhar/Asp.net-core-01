using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface IRequestService
    {
        Task CreateRequest(RequestCreateRequestViewModel requestCreateRequestViewModel);
        Task EditRequest(RequestEditRequestViewModel editRequest, long requestId);
        Task DeleteRequest(long requestId);
        Task<List<RequestResultViewModel>> GetAllRequests();
        Task<RequestDetailsResultViewModel> GetRequestDetail(long requestId);
        Task<DtResult<RequestResultViewModel>> GetData(DtParameters dtParameters);
    }
}
