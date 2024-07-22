using Shared.Modelviews.User;

namespace EventManager.Shared.Modelviews    
{
    public class UpdateUser : NewUser
    {
        public new string Email { get; set; }   = string.Empty; 
    }
}