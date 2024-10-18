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

        public async Task CreateCustomer(CustomerCreateRequestViewModel createRequest)
        {
            var newCustomer = new Customer
            {
                FullName = createRequest.FullName,
                ProvinceId = createRequest.ProvinceId,
                TownshipId = createRequest.TownshipId,
                PhoneNumber = createRequest.PhoneNumber,
                Address = createRequest.Address,
                Description = createRequest.Description,
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
        public async Task EditCustomer(CustomerEditRequestViewModel editRequest, long customerId)
        {
            var newCustomer = await _customerRepository.GetCustomerById(customerId);
            newCustomer.FullName = editRequest.FullName;
            newCustomer.ProvinceId = editRequest.ProvinceId;
            newCustomer.TownshipId = editRequest.TownshipId;
            newCustomer.PhoneNumber = editRequest.PhoneNumber;
            newCustomer.Address = editRequest.Address;
            newCustomer.Description = editRequest.Description;
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
        public async Task<CustomerDetailsResultViewModel> GetCustomerDetails(long customerId)
        {
            return await _customerRepository.GetCustomerDetails(customerId);
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
