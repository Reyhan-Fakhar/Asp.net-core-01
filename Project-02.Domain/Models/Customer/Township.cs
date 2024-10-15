using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02.Domain.Models.Customer
{
    public class Township
    {
        [Key]
        public int TownshipId { get; set; }

        [Display(Name = "نام شهرستان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string TownshipName { get; set; }

        #region Relation
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }

        public List<Customer> Customers { get; set; }
        #endregion

    }
}
