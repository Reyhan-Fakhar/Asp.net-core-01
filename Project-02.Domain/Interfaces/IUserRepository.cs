using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region User
        Task AddUser(User user);
        Task UpdateUser(User user);
        bool IsExistUserName(string userName);
        Task<List<UserResultViewModel>> GetAllUsers();
        Task<User> GetUserById(long userId);
        Task<List<User>> GetUsersByRoleId(long roleId);
        Task<UserDetailsResultViewModel> GetUserDetails(long userId);
        #endregion
    }
}
