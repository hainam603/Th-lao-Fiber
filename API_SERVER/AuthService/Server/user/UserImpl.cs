using System;
using System.Data;
using System.Linq;
using Dapper;
using Model;
using Model.Connection;
using Model.Connection.Oracle;
using Model.Model;
using Oracle.ManagedDataAccess.Client;

namespace AuthService.Server.user
{
    public class UserImpl : Iuser
    {
        readonly DataRespond datarespond = new DataRespond();
        readonly Connection connection = new Connection();
        public dynamic Lay_DS_Nguoidung()
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.Lay_ds_nguoi_dung";
                    result = SqlMapper.Query<NguoidungModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "Successfully";

            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
        //Quyền người dùng-----------------------------------------------------------
        public dynamic Lay_DS_Quyen_Nguoidung(string ma_nd)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("vma_nd", OracleDbType.Int32, ParameterDirection.Input, ma_nd);
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.Get_quyen_nd";
                    result = SqlMapper.Query<QuyenNguoidungModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "Successfully";

            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
        //Quyền menu------------------------------------------------------------------
        public dynamic Lay_DS_Menu_Nguoidung(string ma_nd)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("vma_nd", OracleDbType.Int32, ParameterDirection.Input, ma_nd);
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.get_ds_menu_By_ma_nd";
                    result = SqlMapper.Query<MenuNguoidungModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "Successfully";

            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
        public dynamic Lay_DS_LoaiNV_Nguoidung(string ma_nd)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("vma_nd", OracleDbType.Int32, ParameterDirection.Input, ma_nd);
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.get_ds_loainhanvien";
                    result = SqlMapper.Query<LoaiNhanvienModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "Successfully";

            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
        //Quyền báo cáo ---------------------------------------------------------------
        public dynamic Lay_DS_Nhombaocao_Nguoidung(string ma_nd)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("vma_nd", OracleDbType.Int32, ParameterDirection.Input, ma_nd);
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.get_ds_nhombc_by_ma_nd";
                    result = SqlMapper.Query<NhombaocaoModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "Successfully";

            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
        public dynamic Lay_DS_Baocao_Nguoidung(string ma_nd, int nhom_bc_id)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("vma_nd", OracleDbType.Int32, ParameterDirection.Input, ma_nd);
                dyParam.Add("vnhom_bc_id", OracleDbType.Int32, ParameterDirection.Input, nhom_bc_id);
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.get_ds_baocao_by_nhom_bc_ma_nd";
                    result = SqlMapper.Query<BaocaoModel>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "Successfully";

            }
            catch (Exception ex)
            {
                //throw ex;
                datarespond.success = false;
                datarespond.message = ex.Message;
            }

            return datarespond;
        }
    }
        
    
}
