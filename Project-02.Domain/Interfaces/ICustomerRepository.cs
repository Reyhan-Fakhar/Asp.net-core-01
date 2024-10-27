using Project_02.Domain.Models.Customer;
using Project_02.Domain.Models.Request;
using Project_02.Domain.ViewModels;

namespace Project_02.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
        Task AddCustomers(List<Customer> customer);
        Task UpdateCustomer(Customer customer);
        Task<List<CustomerResultViewModel>> GetAllCustomers();
        Task<Customer> GetCustomerById(long customerId);
        Task<CustomerDetailsResultViewModel> GetCustomerDetails(long customerId);

        #region Province-Township
        Task<List<Province>> GetAllProvinces();
        Task<List<Township>> GetTownshipsByProvinceId(int provinceId);

        #endregion
    }
}
