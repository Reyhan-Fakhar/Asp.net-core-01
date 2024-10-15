using Project_02.Domain.Models.Customer;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomer(CustomerRequestViewModel request);
        Task EditCustomer(CustomerRequestViewModel request, long customerId);
        Task DeleteCustomer(long customerId);
        Task<Customer> GetCustomerById(long customerId);
        Task<List<CustomerResultViewModel>> GetAllCustomers();
        //Task<IEnumerable<CustomerResultViewModel>> GetAllCustomers();

        #region Province-Township
        Task<List<Province>> GetAllProvinces();
        Task<List<Township>> GetTownshipsByProvinceId(int provinceId);

        #endregion
    }
}
