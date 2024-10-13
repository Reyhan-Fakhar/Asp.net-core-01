using Project_02.Application.Interfaces;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Customer;
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
                Province = request.Province,
                City = request.City,
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
        public async Task EditCustomer(CustomerRequestViewModel request)
        {
            var newCustomer = new Customer
            {
                FullName = request.FullName,
                Province = request.Province,
                City = request.City,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Description = request.Description,
            };

            await _customerRepository.UpdateCustomer(newCustomer);
        }
        //public async Task<IEnumerable<CustomerResultViewModel>> GetAllCustomers()
        //{
        //    //var result = await _customerRepository.GetAllCustomers();
        //}
    }
}
