using System.Collections.Generic;
using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Model.Connection.Oracle
{
    public interface IOracleDyamicParameters
    {
        void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null);
        void Add(string name, OracleDbType oracleDbType, ParameterDirection direction);
        void AddParameters(IDbCommand command, SqlMapper.Identity identity);

        IDbConnection GetConnection();
    }
}
