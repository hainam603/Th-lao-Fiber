using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DataRespond
    {
        public Boolean success { get; set; }
        public string message { get; set; }
        public dynamic error { get; set; }
        public dynamic data { get; set; }
    }
}
