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

        //Insert thuê bao mới
        public dynamic Insert(NewModel newModel)
        {
            dynamic result = null;
            try
            {

                oracle.Add("ma_tb", OracleDbType.Varchar2, ParameterDirection.Input, newModel.ma_tb);
                oracle.Add("tb_cd_dongquang", OracleDbType.Int32, ParameterDirection.Input, newModel.tb_cd_dongquang);
                oracle.Add("huy_truoc_30ngay", OracleDbType.Int32, ParameterDirection.Input, newModel.huy_truoc_30ngay);
                oracle.Add("khongthuoc_khuvuc_pttb", OracleDbType.Int32, ParameterDirection.Input, newModel.khongthuoc_khuvuc_pttb);
                oracle.Add("thang_hoamang", OracleDbType.Varchar2, ParameterDirection.Input, newModel.thang_hoamang);
                oracle.Add("ngay_hoamang", OracleDbType.Date, ParameterDirection.Input, newModel.ngay_hoamang);
                oracle.Add("ngay_ins", OracleDbType.Date, ParameterDirection.Input, newModel.ngay_ins);
                oracle.Add("trangthai", OracleDbType.Varchar2, ParameterDirection.Input, newModel.trangthai);
                oracle.Add("goi_tratruoc", OracleDbType.Int32, ParameterDirection.Input, newModel.goi_tratruoc);
                oracle.Add("tocdo_id", OracleDbType.Int32, ParameterDirection.Input, newModel.tocdo_id);
                oracle.Add("ma_NVKT_TT", OracleDbType.Varchar2, ParameterDirection.Input, 1);
                oracle.Add("id_NVKT_TT", OracleDbType.Int32, ParameterDirection.Input, 1);
                oracle.Add("hdtb_id", OracleDbType.Int32, ParameterDirection.Input, newModel.hdtb_id);
                oracle.Add("hdkh_id", OracleDbType.Int32, ParameterDirection.Input, newModel.hdkh_id);
                oracle.Add("thuebao_id", OracleDbType.Int32, ParameterDirection.Input, newModel.thuebao_id);
                oracle.Add("kieuld_id", OracleDbType.Int32, ParameterDirection.Input, newModel.kieuld_id);
                oracle.Add("ma_gd", OracleDbType.Varchar2, ParameterDirection.Input, newModel.ma_gd);
                oracle.Add("phongbh", OracleDbType.Varchar2, ParameterDirection.Input, newModel.phongbh);
                oracle.Add("phongbh_id", OracleDbType.Int32, ParameterDirection.Input, newModel.phongbh_id);
                oracle.Add("ten_tb", OracleDbType.Varchar2, ParameterDirection.Input, newModel.ten_tb);
                oracle.Add("diachi_ld", OracleDbType.Varchar2, ParameterDirection.Input, newModel.diachi_ld);
                oracle.Add("ngay_tt", OracleDbType.Date, ParameterDirection.Input, newModel.ngay_tt);
                oracle.Add("tb_dungthu", OracleDbType.Int32, ParameterDirection.Input, newModel.tb_dungthu);
                oracle.Add("ngay_tao", OracleDbType.Date, ParameterDirection.Input, newModel.ngay_tao);
                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "Mivtt.PK_FIBER.Themmoi_1dong_dulieu_PTM_Fiber";
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

        public dynamic Update(NewModel New)
        {
            throw new NotImplementedException();
        }

        //Tìm thông tin theo ma_tb
        public dynamic Get_Info_ByID(string ma_tb)
        {
            dynamic result = null;
            try
            {
                oracle.Add("v_matb", OracleDbType.Varchar2, ParameterDirection.Input, ma_tb);
                oracle.Add("o_data", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = connection.GetConnectionOracle();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    var query = "Mivtt.PK_FIBER.LayTT_Theo_MATB";
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
