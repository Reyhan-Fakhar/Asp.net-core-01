using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project_02.Domain.Models.Common;

namespace Project_02.Domain.Models.Permissions
{
    public class Permission : BaseEntity
    {
        [Key]
        public long PermissionId { get; set; }

        [Display(Name = "عنوان دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PermissionTitle { get; set; }
        public long? ParentId { get; set; }


        [ForeignKey("ParentId")]
        public List<Permission> Permissions { get; set; }

        public List<RolePermission> RolePermissions { get; set; }
    }
}
