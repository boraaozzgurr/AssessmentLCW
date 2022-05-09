using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Global.Request
{
    public class CustomerOrderDetailUpdateRequest
    {
        public int CustomerOrderDetailId { get; set; }
        public float Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
