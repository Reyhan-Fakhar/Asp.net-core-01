using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;

namespace Project_02.Infrastructure.Data.Seeder
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            const string jsonUser = "[{\"UserId\":1,\"UserName\":\"ریحان\",\"FullName\":\"ریحانه فخارزاده\",\"Password\":\"1881\",\"PhoneNumber\":\"09130992852\",\"IsActive\":true,\"RoleId\":1}]";

            var users = JsonConvert.DeserializeObject<List<Permission>>(jsonUser);

            builder.HasData(users);
        }
    }
}
