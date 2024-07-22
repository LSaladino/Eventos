using EventManager.Shared.Modelviews.Event;
using FluentValidation;

namespace Manager.Validators
{
    public class NewEventValidator : AbstractValidator<NewEvent>
    {
        public NewEventValidator()    
        {
            
        }
    }
}