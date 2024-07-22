using AutoMapper;
using Core.Domain;
using Shared.Modelviews.Customer;

namespace Manager
{
    public class UpdateCustomerMappingProfile : Profile
    {
        public UpdateCustomerMappingProfile()
        {
            CreateMap<UpdateCustomer, Customer>();
        }
    }
}
