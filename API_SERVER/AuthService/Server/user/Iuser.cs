using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Server.user
{
    public interface Iuser
    {
        dynamic Lay_DS_Nguoidung();
        //Quyền người dùng
        dynamic Lay_DS_Quyen_Nguoidung(string ma_nd);
        //Quyền menu
        dynamic Lay_DS_Menu_Nguoidung(string ma_nd);
        dynamic Lay_DS_LoaiNV_Nguoidung(string ma_nd);
        //Quyên báo cáo
        dynamic Lay_DS_Nhombaocao_Nguoidung(string ma_nd);
        dynamic Lay_DS_Baocao_Nguoidung(string ma_nd, int nhom_bc_id);
    }
}
