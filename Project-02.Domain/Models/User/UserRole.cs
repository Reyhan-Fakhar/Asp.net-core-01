using System.ComponentModel.DataAnnotations;
using Project_02.Domain.Models.Common;

namespace Project_02.Domain.Models.User
{
    public class UserRole : BaseEntity
    {
        public UserRole() { }
        [Key]
        public long UserRoleId { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }

        #region Relation
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        #endregion
    }
}
