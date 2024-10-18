using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02.Domain.Models.Common;


namespace Project_02.Domain.Models.Request
{
    public class Request : BaseEntity
    {
        public Request() { }

        [Key]
        public long RequestId { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }
        
        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime Date { get; set; }

        #region Relation

        public long CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer.Customer Customer { get; set; }
        #endregion
    }
}
