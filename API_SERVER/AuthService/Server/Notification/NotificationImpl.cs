using System;
using System.Data;
using System.Linq;
using Dapper;
using Model;
using Model.Connection;
using Model.Connection.Oracle;
using Model.Model;
using Oracle.ManagedDataAccess.Client;

namespace AuthService.Server.Notification
{
    public class NotificationImpl : Inotification
    {
        DataRespond datarespond = new DataRespond();
        Connection connection = new Connection();
        public dynamic Lay_DS_Thaydoi_I8(RangeDateRequestModel rdrm)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("vtungay", OracleDbType.Varchar2, ParameterDirection.Input, rdrm.tu_ngay);
                dyParam.Add("vdenngay", OracleDbType.Varchar2, ParameterDirection.Input, rdrm.den_ngay);
                dyParam.Add("cur_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "API_01.Get_ds_thay_doi_i8";
                    result = SqlMapper.Query<DanhsachThaydoiI8Model>(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                }

                datarespond.success = true;
                datarespond.data = result;
                datarespond.message = "get list I8 modified successfully";

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
