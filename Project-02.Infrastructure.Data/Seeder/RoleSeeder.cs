using Microsoft.EntityFrameworkCore;
using Project_02.Domain.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project_02.Infrastructure.Data.Seeder
{
    public class RoleSeeder : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            const string jsonUser = "[{\"RoleId\":1,\"RoleName\":\"ادمین\"}]";
        }
    }
}
