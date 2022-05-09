using LCWAssessment.Global.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Global.Model
{
    public class Customer : Common
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
