using LCWAssessment.Global.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCWAssessment.Global.Request
{
    public class CustomerOrderUpdateRequest
    {


        [Required(ErrorMessage = "CustomerId Cannot Be Null")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "CustomerOrderId Cannot Be Null")]
        public int CustomerOrderId { get; set; }

        public string CustomerAddress { get; set; }

        public List<CustomerOrderDetailUpdateRequest> OrderDetailList { get; set; }

    }
}
