using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Request;
using Project_02.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_02.Application.Convertor;
using Project_02.Infrastructure.Data.Context;

namespace Project_02.Infrastructure.Data.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataBaseContext _context;

        public RequestRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task AddRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRequest(Request request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RequestResultViewModel>> GetAllRequests()
        {
            return await _context.Requests
                .Include(x => x.Customer)
                .Select(request => new RequestResultViewModel()
                {
                    RequestId = request.RequestId,
                    CustomerName = request.Customer.FullName,
                    Date = request.Date.ToShamsi(),
                    Province = request.Customer.Province.ProvinceName,
                    Township = request.Customer.Township.TownshipName,
                    Description = request.Description,

                }).ToListAsync();
        }
        public async Task<Request> GetRequestById(long requestId)
        {
            return await _context.Requests.FindAsync(requestId);
        }
        public async Task<List<Request>> GetAllCustomerRequests(long customerId)
        {
            var requestIds = await _context.Requests
                .Where(r => r.CustomerId == customerId)
                .Select(r => r.RequestId).ToListAsync();
            return await _context.Requests
                .Where(r => requestIds.Contains(r.RequestId))
                .ToListAsync();
        }
        public async Task<RequestDetailsResultViewModel> GetRequestDetails(long requestId)
        {
            var request = await GetRequestById(requestId);
            
            var requestDetails = new RequestDetailsResultViewModel()
            {
                CustomerDetails = request.Customer,
                Date = request.Date.ToShamsi(),
                Description = request.Description,
            };

            return requestDetails;
        }

    }
}
