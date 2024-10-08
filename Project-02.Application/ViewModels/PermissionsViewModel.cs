using Project_02.Domain.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Project_02.Application.ViewModels
{
    public class PermissionsViewModel
    {
        public class RoleResultViewModel
        {
            public List<Role> Roles { get; set; }
            public int CurrentPage { get; set; }
            public int PageCount { get; set; }
        }
        public class RoleRequestViewModel
        {
            [Display(Name = "نقش کاربر")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
            public string RoleName { get; set; }
        }
    }
}
