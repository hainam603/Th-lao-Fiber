using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Model;
using Model.Connection;
using Model.Connection.Oracle;
using Model.Model.New;
using Oracle.ManagedDataAccess.Client;

namespace Fiber.Server.New
{
    public class NewImpl : INew
    {
        readonly DataRespond datarespond = new DataRespond();
        readonly Connection connection = new Connection();
        private IOracleDyamicParameters oracle;
        public NewImpl(IOracleDyamicParameters oracle)
        {
            this.oracle = oracle;
        }

        public dynamic Get_List_New(string month)
        {
            dynamic result = null;
            try
            {
                oracle.Add("v_thang", OracleDbType.Varchar2, ParameterDirection.Input, month);
                oracle.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "Mivtt.PK_FIBER.LAYDS_PTM_FIBER_THEO_THANG";
                    result = SqlMapper.Query<NewModel>(conn, query, param: oracle, commandType: CommandType.StoredProcedure).ToList();
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
        

        public dynamic Insert_List_New(string month)
        {
            dynamic result = null;
            try
            {
                oracle.Add("v_thang", OracleDbType.Varchar2, ParameterDirection.Input, month);
                oracle.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "Mivtt.PK_FIBER.TaoDS_PTM_Fiber_Theo_Thang";
                    result =  SqlMapper.Query(conn, query, param: oracle, commandType: CommandType.StoredProcedure);
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

        public dynamic Delete_List_New(string month)
        {
            dynamic result = null;
            try
            {
                oracle.Add("v_thang", OracleDbType.Int32, ParameterDirection.Input, month);
                oracle.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "Mivtt.PK_FIBER.XoaDS_PTM_Fiber_Theo_Thang";
                    result = SqlMapper.Execute(conn, query, param: oracle, commandType: CommandType.StoredProcedure);
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

        public dynamic Delete(NewModel New)
        {
            throw new NotImplementedException();
        }
        public dynamic Insert(NewModel New)
        {
            throw new NotImplementedException();
        }

        public dynamic Update(NewModel New)
        {
            throw new NotImplementedException();
        }

        public dynamic GetID(NewModel New)
        {
            throw new NotImplementedException();
        }

        public dynamic Get_List_News(int year)
        {
            dynamic result = null;
            try
            {
                oracle.Add("v_nam", OracleDbType.Int32, ParameterDirection.Input, year);
                oracle.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "Mivtt.PK_FIBER.LayDS_Cac_Thang_PTM_Fiber";
                    result = SqlMapper.Query<ListNewModel>(conn, query, param: oracle, commandType: CommandType.StoredProcedure).ToList();
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
