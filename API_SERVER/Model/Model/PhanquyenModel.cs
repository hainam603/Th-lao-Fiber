using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class PhanquyenModel
    {
        [Key]
        public string ma_nd { get; set; }
        public int quyen_id { get; set; }
        public string ten_nd { get; set; }
        public PhanquyenModel(string ma_nd, int quyen_id, string ten_nd)
        {
            this.ma_nd = ma_nd;
            this.quyen_id = quyen_id;
            this.ten_nd = ten_nd;
        }
    }
}
