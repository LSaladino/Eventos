using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyContext _myContext;

        public CustomerRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var customerFinded = await _myContext.Customers.FindAsync(id);

            if (customerFinded == null) { return null; }

            var customerRemoved = _myContext.Customers.Remove(customerFinded);
            await _myContext.SaveChangesAsync();
            return customerRemoved.Entity;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _myContext.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _myContext.Customers
                //.Include(ev => ev.Events)
                .SingleOrDefaultAsync(ev => ev.Id == id);

            return customer!;
                //.FindAsync(id);
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            await _myContext.Customers.AddAsync(customer);
            await _myContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var customerFind = await _myContext.Customers.FindAsync(customer.Id);
            if (customerFind != null)
            {
                _myContext.Entry(customerFind).CurrentValues.SetValues(customer);
                await _myContext.SaveChangesAsync();
                return customerFind;
            }
            return null;
        }
    }
}
