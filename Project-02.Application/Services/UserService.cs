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
        public async Task<ResultsViewModel> CreateUser(UserCreateRequestViewModel createRequest)
        {
            if (_userRepository.IsExistUserName(createRequest.UserName))
                return new ResultsViewModel()
                {
                    IsSuccess = false,
                    Message = "نام کاربری وارد شده در سیستم وجود دارد"
                };
            var newUser = new User
            {
                UserName = createRequest.UserName,
                FullName = createRequest.FullName,
                Password = createRequest.Password,
                PhoneNumber = createRequest.PhoneNumber,
                RoleId = createRequest.RoleId,
                IsActive = true,
            };

            await _userRepository.AddUser(newUser);
            return new ResultsViewModel()
            {
                IsSuccess = true,
                Message = ""
            };

        }
        public async Task DeleteUser(long userId)
        {
            var user = await _userRepository.GetUserById(userId);
            user.IsRemoved = true;
            user.RemoveTime = DateTime.Now;
            await _userRepository.UpdateUser(user);
        }
        public async Task UpdateUser(UserEditRequestViewModel createRequest, long userId)
        {
            var newUser = await _userRepository.GetUserById(userId);
            newUser.UserId = userId;
            newUser.UserName = createRequest.UserName;
            newUser.FullName = createRequest.FullName;
            if (!string.IsNullOrWhiteSpace(createRequest.Password))
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

        public async Task<List<User>> GetUsersByRoleId(long roleId)
        {
            return await _userRepository.GetUsersByRoleId(roleId);
        }
        public async Task<UserEditRequestViewModel> GetUserByIdViewModel(long userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return new UserEditRequestViewModel()
            {
                UserName = user.UserName,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                RoleId = user.RoleId,
            };
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
