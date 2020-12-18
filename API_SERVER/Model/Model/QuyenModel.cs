using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class QuyenModel
    {
        [Key]
        public int quyen_id { get; set; }
        public string ten_quyen { get; set; }
        public QuyenModel(int quyen_id, string ten_quyen)
        {
            this.quyen_id = quyen_id;
            this.ten_quyen = ten_quyen;
        }
    }
}
