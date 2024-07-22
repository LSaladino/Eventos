using Core.Domain.Model.User;

namespace Manager.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserAsync(); 
        Task<User> GetByLoginAsync(string login);          
        Task<User> InsertUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
    }
}
