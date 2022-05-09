using LCWAssessment.Global.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Global.Request
{
    public  class CustomerOrderResponse
    {
        public List<CustomerOrderDetail> CustomerOrderList { get; set; }
    }
}
