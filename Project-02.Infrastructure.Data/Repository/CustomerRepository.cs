using Microsoft.EntityFrameworkCore;
using Project_02.Application.Convertor;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Customer;
using Project_02.Domain.ViewModels;
using Project_02.Infrastructure.Data.Context;

namespace Project_02.Infrastructure.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataBaseContext _context;
        public CustomerRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CustomerResultViewModel>> GetAllCustomers()
        {
            var result = await _context.Customers
                .Include(x=> x.Province)
                .Include(x=> x.Township)
                .Select(customer => new CustomerResultViewModel()
            {
                CustomerId = customer.CustomerId,
                FullName = customer.FullName,
                CreateDate = customer.InsertTime.ToShamsi(),
                Province = customer.Province.ProvinceName,
                Township = customer.Township.TownshipName,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                Description = customer.Description
            }).ToListAsync();
            return result;

        }
        public async Task<Customer> GetCustomerById(long customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }
        public async Task<CustomerDetailsResultViewModel> GetCustomerDetails(long customerId)
        {
            var customer = await GetCustomerById(customerId);
            var customerDetails = new CustomerDetailsResultViewModel()
            {
                FullName = customer.FullName,
                CreateDate = customer.InsertTime.ToShamsi(),
                Province = customer.ProvinceId.ToString(),
                Township = customer.TownshipId.ToString(),
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                Description = customer.Description,
                //CustomerRequests = customer.Requests,
            };
            return customerDetails;
        }

        #region Province-Township

        public async Task<List<Province>> GetAllProvinces()
        {
            return await _context.Provinces.ToListAsync();
        }

        public async Task<List<Township>> GetTownshipsByProvinceId(int provinceId)
        {
            return await _context.Townships.Where(t => t.ProvinceId == provinceId).ToListAsync();
        }

        #endregion
    }
}
