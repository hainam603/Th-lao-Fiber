using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService.Server.Role.Chucnang
{
    public class ChucnangImpl : SqlserverImpl<ChucnangModel>, Ichucnang
    {
        DataRespond dataRespond = new DataRespond();
        public ChucnangImpl(DataContext dataContext) : base(dataContext)
        {
        }

        public dynamic Lay_DS_Chucnang()
        {
            //return getAll();
            return from cn in dataContext.ChucNang
                           select new
                           {
                               chucnang_id = cn.chucnang_id,
                               icon = cn.icon != null ? cn.icon.Trim() : cn.icon,
                               link = cn.link != null ? cn.link.Trim() : cn.link,
                               title = cn.title != null ? cn.title.Trim() : cn.title,
                               menu = cn.menu,
                               stt = cn.stt
                           };
        }
        public dynamic Lay_DS_Chucnang_Theo_DS_Chucnang_ID(string dschucnang_id)
        {
            string[] sdschucnang_id = dschucnang_id.Split(',');
            int[] myInts = Array.ConvertAll(sdschucnang_id, s => int.Parse(s));
            
            try
            {
                dataRespond.success = true;
                dataRespond.data = from cn in (getAll().Where(c => myInts.Contains(c.chucnang_id)).OrderBy(m => m.menu).ThenBy(s => s.stt))
                                   select new
                                   {
                                       chucnang_id = cn.chucnang_id,
                                       icon = cn.icon != null ? cn.icon.Trim() : "",
                                       link = cn.link != null ? cn.link.Trim() : "",
                                       title = cn.title != null ? cn.title.Trim() : "",
                                       menu = cn.menu,
                                       stt = cn.stt
                                   };
                dataRespond.message = "Successfully";
            }
            catch (Exception ex)
            {
                dataRespond.success = false;
                dataRespond.message = ex.ToString();
            }
            return dataRespond;
        }

        public dynamic Lay_DS_Chucnang_Theo_Quyen_ID(int quyen_id)
        {
            try
            {
                List<int> ds_chucnang_id = (from qsdcn in dataContext.QuyenSudungChucnang.Where(c => c.quyen_id == quyen_id)
                                     select qsdcn.chucnang_id).ToList<int>();
                dataRespond.success = true;
                dataRespond.data = from cn in dataContext.ChucNang.Where(c => ds_chucnang_id.Contains(c.chucnang_id))
                                   select new
                                   {
                                       chucnang_id = cn.chucnang_id,
                                       icon = cn.icon != null ? cn.icon.Trim() : "",
                                       link = cn.link != null ? cn.link.Trim() : "",
                                       title = cn.title != null ? cn.title.Trim() : "",
                                       menu = cn.menu,
                                       stt = cn.stt
                                   };
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
