using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class ChucnangModel
    {
        [Key]
        public int chucnang_id { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
        public Boolean menu { get; set; }
        public int stt { get; set; }
    }
}
