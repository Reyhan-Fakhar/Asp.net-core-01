using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02.Domain.Models.Customer
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }

        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProvinceName { get; set; }

        #region Relation
        public List<Township>? Townships { get; set; }
        public List<Customer> Customers { get; set; }
        #endregion
    }
}
