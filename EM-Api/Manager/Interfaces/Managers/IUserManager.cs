using Core.Domain.Model.User;
using EventManager.Shared.Modelviews;
using Shared.Modelviews.User;

namespace EventManager.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<IEnumerable<UserView>> GetUserAsync(); 
        Task<UserView> GetByLoginAsync(string login);  
        Task<UserView> InsertUserAsync(NewUser newUser);
        Task<UserView> UpdateUserAsync(User user);
        Task<LoggedUser> ValidateUserAndTokenGenerateAsync(User user);
    }
}
