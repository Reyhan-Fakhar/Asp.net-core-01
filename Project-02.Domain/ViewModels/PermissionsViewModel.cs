using System.ComponentModel.DataAnnotations;

namespace Project_02.Domain.ViewModels
{
    public class RoleCreateRequestViewModel
    {
        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleName { get; set; }
    }
    public class RoleResultViewModel
    {
        [Display(Name = "ردیف")]
        public long Row { get; set; }

        public long RoleId { get; set; }

        [Display(Name = "نام نقش")]
        public string RoleName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreateDate { get; set; }
        [Display(Name = "عملیات")]
        public string Operation { get; set; }
    }
    public class RoleEditRequestViewModel
    {
        public long RoleId { get; set; }
        [Display(Name = "نقش کاربر")]
        public string RoleName { get; set; }

        public List<long> PermissionsId { get; set; }
        [Display(Name = "سطح دسترسی کاربر")]
        public List<string> PermissionsName { get; set; }
    }
    public class RoleDetailsResultViewModel
    {
        public long RoleId { get; set; }

        [Display(Name = "نام نقش")]
        public string RoleName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreateDate { get; set; }

        public List<long> PermissionsId { get; set; }
        [Display(Name = "سطح دسترسی کاربر")]
        public List<string> PermissionsName { get; set; }
    }
}
