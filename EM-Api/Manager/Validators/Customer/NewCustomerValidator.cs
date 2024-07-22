using Core.Domain;
using FluentValidation;

namespace Manager.Validators
{
    public class NewCustomerValidator : AbstractValidator<Customer>
    {
        public NewCustomerValidator()
        { 
        
        }
    }
}
