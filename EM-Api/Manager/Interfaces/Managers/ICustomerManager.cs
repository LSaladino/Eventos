using Shared.Modelviews.Customer;

namespace Manager.Interfaces.Managers
{
    public interface ICustomerManager
    {
        Task<IEnumerable<CustomerView>> GetAllCustomersAsync();
        Task<CustomerView> GetCustomerByIdAsync(int id);
        Task<CustomerView> InsertCustomerAsync(NewCustomer newCustomer);
        Task<CustomerView> UpdateCustomerAsync(UpdateCustomer updateCustomer);  
        Task<CustomerView> DeleteCustomerAsync(int id);
    }
}
