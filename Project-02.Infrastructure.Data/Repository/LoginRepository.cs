using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.User;
using Project_02.Infrastructure.Data.Context;

namespace Project_02.Infrastructure.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataBaseContext _context;

        public LoginRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }
    }
}
