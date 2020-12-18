using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.Phanquyen
{
    public interface Iphanquyen:Isqlserver<PhanquyenModel>
    {
        dynamic Lay_Quyen_Nguoidung(string ma_nd);
        dynamic Lay_DS_Nguoidung_Theo_Quyen(int quyen_id);
        dynamic Them_Phanquyen_Nguoidung(PhanquyenModel phanquyen);
        dynamic Xoa_Phanquyen_Nguoidung(PhanquyenModel phanquyen);
    }
}
