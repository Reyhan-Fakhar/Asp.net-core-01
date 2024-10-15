using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02.Application.Interfaces;
using Project_02.Application.Services;
using Project_02.Domain.Interfaces;
using Project_02.Infrastructure.Data.Repository;

namespace Project_02.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Application Layer
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IPermissionService, PermissionService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<ILoginService, LoginService>();

            //Infrastructure.Data Layer
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IPermissionRepository, PermissionRepository>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<ILoginRepository, LoginRepository>();
        }
    }
}
