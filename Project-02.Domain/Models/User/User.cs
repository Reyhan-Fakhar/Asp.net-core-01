﻿using System.ComponentModel.DataAnnotations;
using Project_02.Domain.Models.Common;

namespace Project_02.Domain.Models.User
{
    public class User : BaseEntity
    {
        public User() { }

        [Key]
        public long UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(8, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

        [Display(Name = "شماره تلفن")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        #region Relation
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}