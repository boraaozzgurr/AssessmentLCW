using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Global.EF
{
    public abstract class Common
    {      
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public string InsertUser { get; set; } = Environment.MachineName;
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }


    }
}
