using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Project_02.Domain.Models.Permissions;

namespace Project_02.Infrastructure.Data.Seeder
{
    public class PermissionSeeder : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            var jsonPermission =
                "[{\"PermissionId\":1,\"PermissionTitle\":\"مدیریت نقش ها\",\"ParentId\":null}," +
                "{\"PermissionId\":2,\"PermissionTitle\":\"لیست نقش ها\",\"ParentId\":1}," +
                "{\"PermissionId\":3,\"PermissionTitle\":\"افزودن نقش جدید\",\"ParentId\":1}," +
                "{\"PermissionId\":4,\"PermissionTitle\":\"ویرایش نقش\",\"ParentId\":1}," +
                "{\"PermissionId\":5,\"PermissionTitle\":\"حذف نقش\",\"ParentId\":1}," +
                "{\"PermissionId\":6,\"PermissionTitle\":\"مدیریت کاربران\",\"ParentId\":null}," +
                "{\"PermissionId\":7,\"PermissionTitle\":\"لیست کاربران\",\"ParentId\":6}," +
                "{\"PermissionId\":8,\"PermissionTitle\":\"افزودن کاربر جدید\",\"ParentId\":6}," +
                "{\"PermissionId\":9,\"PermissionTitle\":\"ویرایش کاربر\",\"ParentId\":6}," +
                "{\"PermissionId\":10,\"PermissionTitle\":\"حذف کاربر\",\"ParentId\":6}," +
                "{\"PermissionId\":11,\"PermissionTitle\":\"مدیریت مشتریان\",\"ParentId\":null}," +
                "{\"PermissionId\":12,\"PermissionTitle\":\"لیست مشتریان\",\"ParentId\":11}," +
                "{\"PermissionId\":13,\"PermissionTitle\":\"افزودن مشتری جدید\",\"ParentId\":11}," +
                "{\"PermissionId\":14,\"PermissionTitle\":\"ویرایش مشتری\",\"ParentId\":11}," +
                "{\"PermissionId\":15,\"PermissionTitle\":\"حذف مشتری\",\"ParentId\":11}," +
                "{\"PermissionId\":16,\"PermissionTitle\":\"مدیریت درخواست ها\",\"ParentId\":null}," +
                "{\"PermissionId\":17,\"PermissionTitle\":\"افزودن درخواست\",\"ParentId\":16}," +
                "{\"PermissionId\":18,\"PermissionTitle\":\"ویرایش درخواست\",\"ParentId\":16}," +
                "{\"PermissionId\":19,\"PermissionTitle\":\"حذف درخواست\",\"ParentId\":16}," +
                "{\"PermissionId\":20,\"PermissionTitle\":\"لیست درخواست ها\",\"ParentId\":16}]";


            var permissions = JsonConvert.DeserializeObject<List<Permission>>(jsonPermission);

            builder.HasData(permissions);
        }
    }
}
