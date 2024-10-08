using System.ComponentModel.DataAnnotations;
using Project_02.Domain.Models.Common;
using Project_02.Domain.Models.Permissions;

namespace Project_02.Domain.Models.User
{
    public class Role : BaseEntity
    {
        public Role() { }
        [Key]
        public long RoleId { get; set; }
        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleName { get; set; }

        #region Relation
        public virtual List<UserRole> UserRoles { get; set; }
        public List<RolePermission> Permissions { get; set; }
        #endregion
    }
}
