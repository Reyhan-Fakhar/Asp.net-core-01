using Project_02.Domain.Models.User;
using System.ComponentModel.DataAnnotations;
using Project_02.Domain.Models.Common;

namespace Project_02.Domain.Models.Permissions
{
    public class RolePermission : BaseEntity
    {
        [Key]
        public long RolePermissionId { get; set; }
        public long RoleId { get; set; }
        public long PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
