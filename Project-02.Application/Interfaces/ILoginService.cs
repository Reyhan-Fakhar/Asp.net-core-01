using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02.Application.Interfaces
{
    public interface ILoginService
    {
        Task<User> AuthenticateUserAsync(UserLoginViewModel model);
    }
}
