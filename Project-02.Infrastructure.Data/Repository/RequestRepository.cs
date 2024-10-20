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
using Project_02.Application.Helper;
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
            return await _context.Requests
                .Include(x => x.Customer)
                .ThenInclude(x => x.Province)
                .ThenInclude(x => x.Townships)
                .FirstOrDefaultAsync(x => x.RequestId == requestId);
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
        public async Task<DtResult<RequestResultViewModel>> GetData(DtParameters dtParameters)
        {
            try
            {
                var searchBy = dtParameters.Search?.Value;


                var result = _context.Requests
                    .Include(r => r.Customer)
                    .ThenInclude(r => r.Province)
                    .ThenInclude(r => r.Townships)
                    .AsQueryable();

                var column = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                var sort = dtParameters.Order[0].Dir.ConvertDtOrderDirToSort();


                switch (column)
                {
                    case "title":
                        result = sort == Sort.OrderBy ? result.OrderBy(c => c.Customer.FullName) : result.OrderByDescending(c => c.Customer.FullName);
                        break;

                    case "code":
                        result = sort == Sort.OrderBy ? result.OrderBy(c => c.Date) : result.OrderByDescending(c => c.Date);
                        break;

                    case "customerName":
                        result = sort == Sort.OrderBy ? result.OrderBy(c => c.Description) : result.OrderByDescending(c => c.Description);
                        break;

                    case "lastOrderStageTitle":
                        result = sort == Sort.OrderBy ? result.OrderBy(c => c.Customer.Province.ProvinceName) : result.OrderByDescending(c => c.Customer.Province.ProvinceName);
                        break;

                    case "userName":
                        result = sort == Sort.OrderBy ? result.OrderBy(c => c.Customer.Township.TownshipName) : result.OrderByDescending(c => c.Customer.Township.TownshipName);
                        break;

                    default:
                        result = sort == Sort.OrderBy ? result.OrderBy(c => c.RequestId) : result.OrderByDescending(c => c.RequestId);
                        break;
                }


                if (!string.IsNullOrEmpty(searchBy))
                {
                    result = result.Where(x =>
                        x.Customer.FullName.Contains(searchBy) ||
                        x.Description.Contains(searchBy) ||
                        x.Customer.Province.ProvinceName.Contains(searchBy) ||
                        x.Customer.Township.TownshipName.Contains(searchBy));
                }

                var filteredResultsCount = await result.CountAsync();
                var totalResultsCount = await _context.Requests.CountAsync();

                var finalResult = new DtResult<RequestResultViewModel>
                {
                    Draw = dtParameters.Draw,
                    RecordsTotal = totalResultsCount,
                    RecordsFiltered = filteredResultsCount,
                    Data = await result
                        .Skip(dtParameters.Start)
                        .Take(dtParameters.Length)
                        .Select(x => new RequestResultViewModel()
                        {
                            Date = x.Date.ToShamsi(),
                            Description = x.Description,
                            CustomerName = x.Customer.FullName,
                            Province = x.Customer.Province.ProvinceName,
                            Township = x.Customer.Township.TownshipName,

                        })

                        .ToListAsync()
                };

                return finalResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

    }
}
