using System;
using System.Security.Claims;
using Model.Connection.SQLServer;
using Model.Model;

namespace Model.CheckPermissions
{
    public interface ICheckPermissions:Isqlserver<QuyenModel>
    {
        Boolean CheckPermissionForUser(ClaimsPrincipal user, int chucnang_id);
    }
}
