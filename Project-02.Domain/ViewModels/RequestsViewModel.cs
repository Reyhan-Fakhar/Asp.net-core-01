using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02.Domain.Models.Customer;

namespace Project_02.Domain.ViewModels
{
    public class RequestCreateRequestViewModel
    {
        public long CustomerId { get; set; }
        [Display(Name = "نام مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CustomerName { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime Date { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }

        [Display(Name = "خلاصه اطلاعات مشتری")]
        public List<CustomerDetailsResultViewModel> CustomerDetails { get; set; }
    }
    public class RequestResultViewModel
    {
        [Display(Name = "ردیف")]
        public long Row { get; set; }

        public long RequestId { get; set; }

        [Display(Name = "تاریخ")]
        public string Date { get; set; }

        public long CustomerId { get; set; }
        [Display(Name = "نام مشتری")]
        public string CustomerName { get; set; }

        [Display(Name = "استان")]
        public string Province { get; set; }

        [Display(Name = "شهر")]
        public string Township { get; set; }
        public int TownshipId { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "عملیات")]
        public string Operation { get; set; }
    }
    public class RequestEditRequestViewModel
    {
        public long RequestId { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }

        public long CustomerId { get; set; }
        [Display(Name = "نام مشتری")]
        public string CustomerName { get; set; }

        [Display(Name = "توضیحات")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }

        [Display(Name = "خلاصه اطلاعات مشتری")]
        public List<CustomerDetailsResultViewModel> CustomerDetails { get; set; }
    }
    public class RequestDetailsResultViewModel
    {
        public long RequestId { get; set; }

        [Display(Name = "تاریخ")]
        public string Date { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "اطلاعات مشتری")]
        public Customer CustomerDetails { get; set; }

    }
}
