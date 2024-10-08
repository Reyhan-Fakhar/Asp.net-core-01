using Project_02.Application.Interfaces;
using Project_02.Application.ViewModels;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.User;

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
        public async Task CreateUser(UserRequestViewModel request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                IsActive = true,
                InsertTime = DateTime.Now
            };

            var userRoles = request.Roles
                .Select(item => _userRepository.GetRoleById(item.RoleId))
                .Select(role => new UserRole() { Role = role, RoleId = role.RoleId, User = newUser, UserId = newUser.UserId })
                .ToList();

            newUser.UserRoles = userRoles;
            await _userRepository.AddUser(newUser);
        }
        public async Task DeleteUser(long userId)
        {
            var user = await _userRepository.GetUserById(userId);
            user.IsRemoved = true;
            user.RemoveTime = DateTime.Now;
            await _userRepository.UpdateUser(user);
        }
        public async Task EditUser(UserRequestViewModel request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                IsActive = true,
                UpdateTime = DateTime.Now
            };
            await _userRepository.DeleteRoleFromUser(newUser.UserId);
            var userRoles = request.Roles
                .Select(item => _userRepository.GetRoleById(item.RoleId))
                .Select(role => new UserRole() { Role = role, RoleId = role.RoleId, User = newUser, UserId = newUser.UserId })
                .ToList();

            newUser.UserRoles = userRoles;
            await _userRepository.UpdateUser(newUser);
        }
        public async Task<IEnumerable<UserResultViewModel>> GetAllUsers(int pageId = 1, int take = 20)
        {
            var result = await _userRepository.GetAllUsers();
            var skip = (pageId - 1) * take;

            return result.Select(u => new UserResultViewModel()
            {
                CurrentPage = pageId,
                PageCount = result.Count() / take,
                Users = result.OrderBy(ui => ui.UserId).Skip(skip).Take(take).ToList()
            });
        }
        #endregion

    }
}
