using Project_02.Domain.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomer(CustomerRequestViewModel request);
        Task EditCustomer(CustomerRequestViewModel request);
        Task DeleteCustomer(long CustomerId);
        //Task<IEnumerable<CustomerResultViewModel>> GetAllCustomers();
    }
}
