using System.ComponentModel.DataAnnotations;

namespace Project_02.Domain.ViewModels
{
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
    public class RoleRequestViewModel
    {
        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleName { get; set; }
    }

}
