using Project_02.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> AuthenticateAsync(string userName, string password);
    }
}
