using LCWAssessment.Global.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LCWAssessment.Global.Model
{
    [Table("Product")]
    public class Product : Common
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Weight { get; set; }
        public int ColorCode { get; set; }
        public float Barcode { get; set; }
        public string Description { get; set; }
        
    }
}
