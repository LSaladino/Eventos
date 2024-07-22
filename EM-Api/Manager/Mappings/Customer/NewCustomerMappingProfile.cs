using AutoMapper;
using Core.Domain;
using Shared.Modelviews.Customer;

namespace Manager
{
    public class NewCustomerMappingProfile : Profile
    {
        public NewCustomerMappingProfile()
        {
            CreateMap<NewCustomer, Customer>();
            CreateMap<Customer, CustomerView>();
        }
    }
}
