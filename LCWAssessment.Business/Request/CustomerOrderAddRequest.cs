using LCWAssessment.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCWAssessment.Business
{



    public class CustomerOrderAddRequest
    {


        [Required(ErrorMessage = "CustomerId Cannot Be Null")]
        public int CustomerId { get; set; }


        public List<CustomerOrderDetail> OrderDetailList { get; set; }

    }
}
