using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Connection.SQLServer;
using Model.Model;
using Newtonsoft.Json;

namespace AuthService.Server.Role.QuyenSudungChucnang
{
    public class QuyenSudungChucnangImpl : SqlserverImpl<QuyenSudungChucnangModel>, IquyenSudungChucnang
    {
        DataRespond dataRespond = new DataRespond();
        public QuyenSudungChucnangImpl(DataContext dataContext) : base(dataContext)
        {
        }

        

        public dynamic Xoa_Quyen_Sudung_Chucnang(RoleUpdateRequestModel roleUpdateRequest)
        {
            try
            { 
                List<QuyenSudungChucnangModel> list = (from qsdcn in dataContext.QuyenSudungChucnang.Where(c => c.quyen_id == roleUpdateRequest.quyen_id) select qsdcn).ToList();
                dataContext.QuyenSudungChucnang.RemoveRange(list);
                dataContext.SaveChanges();
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
        public dynamic Them_Quyen_Sudung_Chucnang(RoleUpdateRequestModel roleUpdateRequest)
        {
            Xoa_Quyen_Sudung_Chucnang(roleUpdateRequest);
            int quyen_id = roleUpdateRequest.quyen_id;
            List<ChucnangModel> ds_chucnang = roleUpdateRequest.ds_chucnang;
            List<QuyenSudungChucnangModel> ds_quyen = new List<QuyenSudungChucnangModel>();
            try
            {
                foreach (ChucnangModel item in ds_chucnang)
                {
                    QuyenSudungChucnangModel quyen = new QuyenSudungChucnangModel(quyen_id, item.chucnang_id);
                    insert(quyen);
                }
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

        dynamic IquyenSudungChucnang.Lay_DS_Quyen_Sudung_Chucnang()
        {
            
            try
            {
                dataRespond.success = true;
                dataRespond.data = getAll();
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }

       

        dynamic IquyenSudungChucnang.Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(int quyen_id)
        {

            try
            {
                var result = getAll().Where(c => c.quyen_id == quyen_id);
                string dschucnang = "";
                foreach (QuyenSudungChucnangModel item in result)
                {
                    dschucnang += item.chucnang_id + ",";
                }
                dschucnang = dschucnang.Substring(0, dschucnang.Length - 1);
                dataRespond.success = true;
                dataRespond.data = new { quyen_id = quyen_id, dschucnang = dschucnang };
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }

       

        dynamic IquyenSudungChucnang.Lay_DS_Quyen_Theo_Chucnang(int chucnang_id)
        {
            var quyen = (from qsdcn in dataContext.QuyenSudungChucnang.Where(m => m.chucnang_id == chucnang_id)
                         join q in dataContext.Quyen on qsdcn.quyen_id equals q.quyen_id
                         select q).ToList<QuyenModel>();
            List<string> dsquyen = new List<string>();
            foreach (QuyenModel q in quyen)
                dsquyen.Add(q.ten_quyen);
            return dsquyen;
        }
    }
}
