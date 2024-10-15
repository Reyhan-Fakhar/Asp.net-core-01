using Microsoft.EntityFrameworkCore;
using Project_02.Application.Interfaces;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Customer;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateCustomer(CustomerRequestViewModel request)
        {
            var newCustomer = new Customer
            {
                FullName = request.FullName,
                ProvinceId = request.ProvinceId,
                TownshipId = request.TownshipId,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Description = request.Description,
            };

            await _customerRepository.AddCustomer(newCustomer);
        }
        public async Task DeleteCustomer(long customerId)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            customer.IsRemoved = true;
            customer.RemoveTime = DateTime.Now;
            await _customerRepository.UpdateCustomer(customer);
        }
        public async Task EditCustomer(CustomerRequestViewModel request, long customerId)
        {
            var newCustomer = await _customerRepository.GetCustomerById(customerId);
            newCustomer.FullName = request.FullName;
            newCustomer.ProvinceId = request.ProvinceId;
            newCustomer.TownshipId = request.TownshipId;
            newCustomer.PhoneNumber = request.PhoneNumber;
            newCustomer.Address = request.Address;
            newCustomer.Description = request.Description;
            newCustomer.UpdateTime = DateTime.Now;

            await _customerRepository.UpdateCustomer(newCustomer);
        }
        public async Task<Customer> GetCustomerById(long customerId)
        {
            return await _customerRepository.GetCustomerById(customerId);
        }
        public async Task<List<CustomerResultViewModel>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        #region Province-Township

        public async Task<List<Province>> GetAllProvinces()
        {
            return await _customerRepository.GetAllProvinces();
        }

        public async Task<List<Township>> GetTownshipsByProvinceId(int provinceId)
        {
            return await _customerRepository.GetTownshipsByProvinceId(provinceId);
        }

        #endregion
    }
}
