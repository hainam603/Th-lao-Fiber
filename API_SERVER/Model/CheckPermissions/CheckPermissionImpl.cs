using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Model.Connection.SQLServer;
using Model.Model;

namespace Model.CheckPermissions
{
    public class CheckPermissionImpl : SqlserverImpl<QuyenModel>, ICheckPermissions
    {
        public CheckPermissionImpl(DataContext dataContext) : base(dataContext)
        {
        }

        public bool CheckPermissionForUser(ClaimsPrincipal user, int chucnang_id)
        {
            var quyen_id = (from pq in dataContext.PhanQuyen.Where(c => c.ma_nd == user.Claims.FirstOrDefault().Value) select pq.quyen_id).FirstOrDefault();
            var p = dataContext.QuyenSudungChucnang.Where(c=>c.chucnang_id==chucnang_id).Where(c=>c.quyen_id==quyen_id).FirstOrDefault();
            if (p == null)
                return false;
            else
                return true;
        }
    }
}
