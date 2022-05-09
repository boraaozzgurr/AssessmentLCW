using LCWAssessment.Global.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCWAssessment.Global.Request
{
    public class CustomerOrderAddRequest
    {


        [Required(ErrorMessage = "CustomerId Cannot Be Null")]
        public int CustomerId { get; set; }

        public List<CustomerOrderDetailAddRequest> OrderDetailList { get; set; }

    }
}
