using LCWAssessment.Global.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCWAssessment.Global.Model
{

    [Table("CustomerOrder")]
    public class CustomerOrder : Common 
    {

        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatus { get; set; }
        public int Status { get; set; } = 1;

    }
}
