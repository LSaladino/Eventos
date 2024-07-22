using AutoMapper;
using Core.Domain;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Shared.Modelviews.Customer;

namespace Manager.Implementation.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerView> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.DeleteCustomerAsync(id);
            return _mapper.Map<CustomerView>(customer);
        }

        public async Task<IEnumerable<CustomerView>> GetAllCustomersAsync()
        {
            var customer = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerView>>(customer);
        }

        public async Task<CustomerView> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            return _mapper.Map<CustomerView>(customer);
        }

        public async Task<CustomerView> InsertCustomerAsync(NewCustomer newCustomer)
        {
            var customer = _mapper.Map<Customer>(newCustomer);
            customer = await _customerRepository.InsertCustomerAsync(customer);
            return _mapper.Map<CustomerView>(customer);
        }

        public async Task<CustomerView> UpdateCustomerAsync(UpdateCustomer updateCustomer)
        {
            var customer = _mapper.Map<Customer>(updateCustomer);
            customer = await _customerRepository.UpdateCustomerAsync(customer);
            return _mapper.Map<CustomerView>(customer);
        }
    }
}
