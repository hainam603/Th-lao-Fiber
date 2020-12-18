using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class NguoidungModel
    {
        public string nguoidung_ID { get; set; } 
        public string ma_ND { get; set; }
        public int nhanvien_ID { get; set; }
        public string ma_NV { get; set; }
        public string ten_NV { get; set; }
        public string so_DT { get; set; }
        public string ten_dv { get; set; }
        public string ten_dvql { get; set; }
        public int trangThai { get; set; }
        public int nhom_nd_id { get; set; }
        public string ten_nhom { get; set; }
        public int quantri { get; set; }
        public string ghiChu { get; set; }
    }
}
