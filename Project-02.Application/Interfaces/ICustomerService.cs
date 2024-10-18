using Project_02.Domain.Models.Customer;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomer(CustomerCreateRequestViewModel createRequest);
        Task EditCustomer(CustomerEditRequestViewModel editRequest, long customerId);
        Task DeleteCustomer(long customerId);
        Task<Customer> GetCustomerById(long customerId);
        Task<List<CustomerResultViewModel>> GetAllCustomers();
        Task<CustomerDetailsResultViewModel> GetCustomerDetails(long customerId);

        #region Province-Township
        Task<List<Province>> GetAllProvinces();
        Task<List<Township>> GetTownshipsByProvinceId(int provinceId);

        #endregion
    }
}
