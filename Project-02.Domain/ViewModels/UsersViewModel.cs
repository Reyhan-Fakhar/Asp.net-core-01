using System.ComponentModel.DataAnnotations;

namespace Project_02.Domain.ViewModels
{
    #region Users-For-Admin
    public class UserCreateRequestViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }

        [Display(Name = "شماره تلفن")]
        [RegularExpression(@"^((98|\+98|0098|0)*(9)[0-9]{9})+$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست.")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public long RoleId { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

    }
    public class UserResultViewModel
    {
        [Display(Name = "ردیف")]
        public long Row { get; set; }

        public long UserId { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
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
    public class UserEditRequestViewModel
    {
        public long UserId { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression(@"^((98|\+98|0098|0)*(9)[0-9]{9})+$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید")]
        public long RoleId { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(8, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string? Password { get; set; }

    }
    #endregion

    #region Users-For-Own
    public class UserLoginViewModel
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
    public class UserDetailsResultViewModel
    {
        public long UserId { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        public long RoleId { get; set; }

        [Display(Name = "نقش کاربر")]
        public string UserRole { get; set; }

        [Display(Name = "سطح دسترسی کاربر")]
        public List<string> PermissionsName { get; set; }

        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Display(Name = "وضعیت")]
        public string IsActive { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreateDate { get; set; }
    }
    public class UserEditRequestViewModelForUserPanel
    {
        public long UserId { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }

        [Display(Name = "شماره تلفن")]
        [RegularExpression(@"^((98|\+98|0098|0)*(9)[0-9]{9})+$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست.")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(8, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }
    }
    #endregion
}
