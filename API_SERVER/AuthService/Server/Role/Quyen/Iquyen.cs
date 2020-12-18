using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role
{
    public interface Iquyen:Isqlserver<QuyenModel>
    {
        dynamic Lay_DS_Quyen();
        dynamic Them_Quyen(QuyenModel quyen);
    }
}
