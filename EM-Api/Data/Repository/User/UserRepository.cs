using Core.Domain;
using Core.Domain.Model.User;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUserAsync() 
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByLoginAsync(string login)  
        {
            var user = await _context.Users
                .Include(x => x.Roles)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email == login);
            return user!;
        }

        public async Task<User> InsertUserAsync(User user)
        {
            //reference by roles
            await InsertUserRolesAsync(user);
            //

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private async Task InsertUserRolesAsync(User user)
        {
            var findedRoles = new List<Role>();

            foreach (var role in user.Roles)
            {
                var findRole = await _context.Roles.FindAsync(role.Id);
                findedRoles.Add(findRole!);
            }

            user.Roles = findedRoles;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var userFind = await _context.Users.FindAsync(user.Email);
            if (userFind != null)
            {
                _context.Entry(userFind).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
                return userFind;
            }
            return null;
        }
    }
}
