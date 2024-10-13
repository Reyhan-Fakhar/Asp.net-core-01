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
        public async Task CreateUser(UserRequestViewModel request)
        {
            var newUser = new User
            {
                UserName = request.UserName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                RoleId = request.RoleId,
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
        public async Task EditUser(UserRequestViewModel request, long userId)
        {
            var newUser = await _userRepository.GetUserById(userId);
            newUser.UserName = request.UserName;
            newUser.Password = request.Password;
            newUser.PhoneNumber = request.PhoneNumber;
            newUser.RoleId = request.RoleId;
            newUser.UpdateTime = DateTime.Now;
            
            await _userRepository.UpdateUser(newUser);
        }
        public async Task<DtResult<UserResultViewModel>> GetData(DtParameters dtParameters)
        {
            var result = await _userRepository.GetData(dtParameters);

            var row = dtParameters.Start + 1;

            foreach (var model in result.Data)
            {
                model.Row = row;
                row++;

                model.Operation =
                    $"<div class=\"dropdown d-inline-block\">" +
                    "<a class=\"nav-link dropdown-toggle arrow-none\" id=\"dLabel6\" data-toggle=\"dropdown\" href=\"#\" role=\"button\" aria-haspopup=\"false\" aria-expanded=\"false\">" +
                    "<i class=\"fas fa-ellipsis-v font-20 text-muted\"></i>" +
                    "</a>" +
                    "<div class=\"dropdown-menu\" aria-labelledby=\"dLabel6\">";

                model.Operation +=
                    $"<a class=\"dropdown-item\" href=\"/User/Edit/{model.UserId}\">" +
                    "<i class=\"dripicons-pencil\"></i> ویرایش" +
                    "</a>";

                model.Operation += $"<a class=\"dropdown-item\" onclick=\"ChangeStatuesUser({model.UserId})\">" +
                                   "<i class=\"dripicons-swap\"></i> تغییر وضعیت" +
                                   "</a>";

                model.Operation += $"<a class=\"dropdown-item\" onclick=\"DeleteUser({model.UserId})\">" +
                                   "<i class=\"dripicons-trash\"></i> حذف" +
                                   "</a>";

                model.Operation += " </div> </div>";
            }
            return result;
        }
        #endregion

    }
}
