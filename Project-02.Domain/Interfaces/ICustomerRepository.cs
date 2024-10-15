﻿using Project_02.Domain.Models.Customer;
using Project_02.Domain.ViewModels;

namespace Project_02.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task<List<CustomerResultViewModel>> GetAllCustomers();
        Task<Customer> GetCustomerById(long customerId);
        Task<bool> IsExistCustomerName(string customerName);

        #region Province-Township
        Task<List<Province>> GetAllProvinces();
        Task<List<Township>> GetTownshipsByProvinceId(int provinceId);

        #endregion
    }
}
