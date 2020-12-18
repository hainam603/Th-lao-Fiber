using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.Phanquyen
{
    public class PhanquyenImpl : SqlserverImpl<PhanquyenModel>, Iphanquyen
    {
        DataRespond dataRespond = new DataRespond();
        public PhanquyenImpl(DataContext dataContext) : base(dataContext)
        {
        }

        public dynamic Lay_DS_Nguoidung_Theo_Quyen(int quyen_id)
        {
            try
            {
                dataRespond.success = true;
                dataRespond.data = (from pq in dataContext.PhanQuyen.Where(c => c.quyen_id == quyen_id) select pq).ToList<PhanquyenModel>();
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
            
        }

        public dynamic Lay_Quyen_Nguoidung(string ma_nd)
        {
            
            try
            {
                dataRespond.success = true;
                dataRespond.data = getById(ma_nd);
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {

                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }

        public dynamic Them_Phanquyen_Nguoidung(PhanquyenModel phanquyen)
        {
            try
            {
                insert(phanquyen);
                dataRespond.success = true;
                dataRespond.message = "Successfully";

            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.data= getById(phanquyen.ma_nd);
                dataRespond.message = ex.ToString() ;
            }
            return dataRespond;
        }

        public dynamic Xoa_Phanquyen_Nguoidung(PhanquyenModel phanquyen)
        {
            try
            {
                delete(phanquyen.ma_nd);
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
