using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.Chucnang
{
    public interface Ichucnang:Isqlserver<ChucnangModel>
    {
        dynamic Lay_DS_Chucnang();
        dynamic Lay_DS_Chucnang_Theo_DS_Chucnang_ID(string dschucnang_id);
        dynamic Lay_DS_Chucnang_Theo_Quyen_ID(int quyen_id);

    }
}
