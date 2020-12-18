using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Model.Connection
{
    public class Connection
    {
        public string connectionStringSQL { get; set; }
        public string connectionStringOracel { get; set; }
        public string connectionStringOracel1 { get; set; }
        public Connection()
        {
            //connectionStringSQL = "Server= HAINAM_PC\\SQLEXPRESS,1433;Database=DB_TEST;User Id=dev;Password=123456;MultipleActiveResultSets=true";
            connectionStringSQL = "Server= localhost;Database=DB_FIBER_TEST;User Id=HOANGPHUC;Password=123456aA@;MultipleActiveResultSets=true";
            connectionStringOracel = "data source=10.70.53.134:1521/SGN;password=Trami@123;user id=Mivtt;Incr Pool Size=5;Decr Pool Size=2;";
            connectionStringOracel1 = "data source=10.70.53.134:1521/SGN;password=Linh$t102018;user id=linhnvu;Incr Pool Size=5;Decr Pool Size=2;";
        }
        public IDbConnection GetConnectionOracle()
        {
            return new OracleConnection(connectionStringOracel);
        }
        public IDbConnection GetConnectionOracle1()
        {
            return new OracleConnection(connectionStringOracel1);
        }
    }
}
