﻿using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;

namespace Project_02.Application.Interfaces
{
    public interface IUserService
    {
        #region User
        Task<ResultsViewModel> CreateUser(UserCreateRequestViewModel createRequest);
        Task UpdateUser(UserEditRequestViewModel createRequest, long userId);
        Task EditUserFromOwn(UserEditRequestViewModelForUserPanel createRequest, long userId);
        Task DeleteUser(long userId);
        Task ChangeStatuesUser(long userId);
        Task<User> GetUserById(long userId);
        Task<List<User>> GetUsersByRoleId(long roleId);
        Task<UserEditRequestViewModel> GetUserByIdViewModel(long userId);
        Task<List<UserResultViewModel>> GetAllUsers();
        Task<UserDetailsResultViewModel> GetUserDetails(long userId);

        #endregion
    }
}
