using Project_02.Application.Interfaces;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region User
        public async Task ChangeStatuesUser(long userId)
        {
            var user = await _userRepository.GetUserById(userId);
            user.IsActive = !user.IsActive;
            await _userRepository.UpdateUser(user);
        }
        public async Task CreateUser(UserCreateRequestViewModel createRequest)
        {
            var newUser = new User
            {
                UserName = createRequest.UserName,
                Password = createRequest.Password,
                PhoneNumber = createRequest.PhoneNumber,
                RoleId = createRequest.RoleId,
                IsActive = true,
            };
            await _userRepository.AddUser(newUser);
        }
        public async Task DeleteUser(long userId)
        {
            var user = await _userRepository.GetUserById(userId);
            user.IsRemoved = true;
            user.RemoveTime = DateTime.Now;
            await _userRepository.UpdateUser(user);
        }
        public async Task EditUserFromAdmin(UserEditRequestViewModel createRequest, long userId)
        {
            var newUser = await _userRepository.GetUserById(userId);
            newUser.UserId = userId;
            newUser.UserName = createRequest.UserName;
            newUser.Password = createRequest.Password;
            newUser.PhoneNumber = createRequest.PhoneNumber;
            newUser.RoleId = createRequest.RoleId;
            newUser.UpdateTime = DateTime.Now;
            
            await _userRepository.UpdateUser(newUser);
        }
        public async Task EditUserFromOwn(UserEditRequestViewModelForUserPanel createRequest, long userId)
        {
            var newUser = await _userRepository.GetUserById(userId);
            newUser.UserId = userId;
            newUser.UserName = createRequest.UserName;
            newUser.Password = createRequest.Password;
            newUser.PhoneNumber = createRequest.PhoneNumber;
            newUser.UpdateTime = DateTime.Now;

            await _userRepository.UpdateUser(newUser);
        }
        public async Task<User> GetUserById(long userId)
        {
            return await _userRepository.GetUserById(userId);
        }
        public async Task<List<UserResultViewModel>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        public async Task<UserDetailsResultViewModel> GetUserDetails(long userId)
        {
            return await _userRepository.GetUserDetails(userId);
        }
        #endregion

    }
}
