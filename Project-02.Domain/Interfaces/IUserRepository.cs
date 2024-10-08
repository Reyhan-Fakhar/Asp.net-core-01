using Project_02.Domain.Models.User;

namespace Project_02.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region User
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(long userId);
        #endregion

        #region Role
        Task DeleteRoleFromUser(long userId);
        Role GetRoleById(long roleId);
        #endregion
    }
}
