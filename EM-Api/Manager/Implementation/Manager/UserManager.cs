using AutoMapper;
using Core.Domain.Model.User;
using EventManager.Interfaces.Managers;
using EventManager.Shared.Modelviews;
using Manager.Interfaces.Repositories;
using Manager.Services;
using Microsoft.AspNetCore.Identity;
using Shared.Modelviews.User;

namespace Manager.Implementation.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJWTService _jwtService;

        public UserManager(IUserRepository userRepository, IMapper mapper, IJWTService jwtService)
        {
            _userRepository = userRepository;   
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<IEnumerable<UserView>> GetUserAsync() 
        {
            var users =  await _userRepository.GetUserAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(users);
        }

        public async Task<UserView> GetByLoginAsync(string login)
        {
            var user =  await _userRepository.GetByLoginAsync(login);
            return _mapper.Map<UserView>(user);
        }

        public async Task<UserView> InsertUserAsync(NewUser newUser)
        {
            var user = _mapper.Map<User>(newUser);

            HasherPasswordConverter(user);

            user = await _userRepository.InsertUserAsync(user);
            return _mapper.Map<UserView>(user);
        }

        private void HasherPasswordConverter(User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);
        }

        public async Task<UserView> UpdateUserAsync(User user)    
        {
            HasherPasswordConverter(user);
            user = await _userRepository.UpdateUserAsync(user);
            return _mapper.Map<UserView>(user);
        }

        public async Task<LoggedUser> ValidateUserAndTokenGenerateAsync(User user)
        {
            var findedUser = await _userRepository.GetByLoginAsync(user.Email);
            if (findedUser == null)
            {
                return null;
            }

            if(await ValidateAndUpdateHashAsync(user, findedUser.Password))
            {
                var loggedUser = _mapper.Map<LoggedUser>(findedUser);
                loggedUser.Token = _jwtService.TokenGenerate(findedUser);
                return loggedUser;
            }
            return null;
        }

        private async Task<bool> ValidateAndUpdateHashAsync(User user, string hash)   
        {
            var passwordHasher = new PasswordHasher<User>();
            var status = passwordHasher.VerifyHashedPassword(user, hash, user.Password);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateUserAsync(user);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
       
    }
}