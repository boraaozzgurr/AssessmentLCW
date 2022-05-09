using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Global.Request
{
    public class Result<T>
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public T Data { get; set; }
    }
}
