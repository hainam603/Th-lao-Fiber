using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.QuyenSudungChucnang
{
    public interface IquyenSudungChucnang:Isqlserver<QuyenSudungChucnangModel>
    {
        dynamic Lay_DS_Quyen_Sudung_Chucnang();
        dynamic Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(int quyen_id);
        dynamic Lay_DS_Quyen_Theo_Chucnang(int chucnang_id);
        dynamic Them_Quyen_Sudung_Chucnang(RoleUpdateRequestModel roleUpdateRequest);
        dynamic Xoa_Quyen_Sudung_Chucnang(RoleUpdateRequestModel roleUpdateRequest);
    }
}
