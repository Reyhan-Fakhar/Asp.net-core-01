using Microsoft.EntityFrameworkCore;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Customer;
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
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(long customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }
    }
}
