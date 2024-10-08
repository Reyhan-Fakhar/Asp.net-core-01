using Project_02.Application.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface IUserService
    {
        #region User
        Task CreateUser(UserRequestViewModel request);
        Task EditUser(UserRequestViewModel request);
        Task DeleteUser(long userId);
        Task ChangeStatuesUser(long userId);
        Task<IEnumerable<UserResultViewModel>> GetAllUsers(int pageId, int take);
        #endregion
    }
}
