using Project_02.Domain.Models.Customer;

namespace Project_02.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(long customerId);
    }
}
