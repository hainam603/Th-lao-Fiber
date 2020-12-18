using System;
using Model;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role
{
    public class QuyenImpl : SqlserverImpl<QuyenModel>, Iquyen
    {
        DataRespond dataRespond = new DataRespond();

        public QuyenImpl(DataContext dataContext) : base(dataContext)
        {
        }

        public dynamic Lay_DS_Quyen()
        {
            
            dynamic result;
            try
            {
                result = getAll();
                dataRespond.success = true;
                dataRespond.data = result;
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }

        public dynamic Them_Quyen(QuyenModel quyen)
        {
            try
            {
                insert(quyen);
                dataRespond.success = true;
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }
    }
}
