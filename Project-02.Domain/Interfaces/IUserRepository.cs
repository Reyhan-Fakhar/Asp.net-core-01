using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region User
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(long userId);
        Task<DtResult<UserResultViewModel>> GetData(DtParameters dtParameters);
        #endregion
    }
}
