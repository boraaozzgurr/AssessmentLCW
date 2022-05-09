using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Global.Model
{
    public  class CustomerOrderDetail
    {
        public int CustomerOrderDetailId { get; set; }
        public int CustomerOrderId { get; set; }
        public float Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; } = 1;
    }
}
