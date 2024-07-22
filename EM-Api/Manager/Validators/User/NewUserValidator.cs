using Core.Domain.Model.User;
using FluentValidation;

namespace Manager.Validators
{
    public class NewUserValidator : AbstractValidator<User>
    {
        public NewUserValidator()
        {
            
        }
    }
}
