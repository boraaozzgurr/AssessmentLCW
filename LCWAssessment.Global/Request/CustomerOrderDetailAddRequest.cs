using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Global.Request
{
    public class CustomerOrderDetailAddRequest
    {
        public float Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
