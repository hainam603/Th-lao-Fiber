using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class RoleUpdateRequestModel
    {
        public int quyen_id { get; set; }
        public List<ChucnangModel> ds_chucnang { get; set; }
    }
}
