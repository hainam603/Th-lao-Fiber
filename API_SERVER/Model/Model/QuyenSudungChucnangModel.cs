using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class QuyenSudungChucnangModel
    {
        [Key]
        public int quyen_id { get; set; }
        [Key]
        public int chucnang_id { get; set; }
        public QuyenSudungChucnangModel(int quyen_id, int chucnang_id)
        {
            this.quyen_id = quyen_id;
            this.chucnang_id = chucnang_id;
        }
    }
}
