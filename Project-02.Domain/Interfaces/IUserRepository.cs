using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region User
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<List<UserResultViewModel>> GetAllUsers();
        Task<User> GetUserById(long userId);
        Task<UserDetailsResultViewModel> GetUserDetails(long userId);
        #endregion
    }
}
