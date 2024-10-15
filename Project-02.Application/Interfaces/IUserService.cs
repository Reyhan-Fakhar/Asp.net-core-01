using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface IUserService
    {
        #region User
        Task CreateUser(UserRequestViewModel request);
        Task EditUser(UserRequestViewModel request, long userId);
        Task DeleteUser(long userId);
        Task ChangeStatuesUser(long userId);
        Task<User> GetUserById(long userId);
        Task<List<UserResultViewModel>> GetAllUsers();
        //Task<List<UserResultViewModel>> GetData(DtParameters dtParameters);

        #endregion
    }
}
