using System.ComponentModel.DataAnnotations;
using Project_02.Domain.Models.User;

namespace Project_02.Domain.ViewModels
{
    #region User
    public class UserResultViewModel
    {
        [Display(Name = "ردیف")]
        public long Row { get; set; }

        public long UserId { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "نقش کاربر")]
        public string UserRole { get; set; }

        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; } 
        
        [Display(Name = "تاریخ ایجاد")]
        public string CreateDate { get; set; } 
        
        [Display(Name = "عملیات")]
        public string Operation { get; set; }
    }

    public class UserUpdatingResultViewModel
    {
        public long UserId { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
    }
    public class UserRequestViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "شماره تلفن")]
        [RegularExpression(@"^((98|\+98|0098|0)*(9)[0-9]{9})+$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public long RoleId { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

    }
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
    #endregion
}
