using System.ComponentModel.DataAnnotations;
using Project_02.Domain.Models.Common;

namespace Project_02.Domain.Models.Customer
{
    public class Customer : BaseEntity
    {
        [Key]
        public long CustomerId { get; set; }

        [Display(Name = "نام مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FullName { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Province { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string City { get; set; }

        [Display(Name = "شماره تلفن")]
        [RegularExpression(@"^((98|\+98|0098|0)*(9)[0-9]{9})+$", ErrorMessage = "شماره تلفن وارد شده معتبر نیست.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

    }
}
