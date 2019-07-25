using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIOracle
{
    public static class Datos
    {
        //string con = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 45.32.22.223)(PORT = 49161)))(CONNECT_DATA =(SERVICE_NAME = xe)));User Id=system;Password=oracle;";
        //string oradb = "Data Source=45.32.22.223:49161/practicas1;User Id=practicasuser;Password=practicasuser14;";
        public static DataTable EjecutarProcedimiento(string name, params OracleParameter[] parametros)
        {
            string connStr = "Data Source=45.32.22.223:49161/xe;User Id=practicas1;Password=practicas114;";
            using (var conn = new OracleConnection(connStr))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = name;
                cmd.CommandType = CommandType.StoredProcedure;


                var qref = new OracleParameter("qref", OracleDbType.RefCursor);
                qref.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(qref);

                if (parametros.Length > 0)
                {
                    cmd.Parameters.AddRange(parametros);
                }


                using (var da = new OracleDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
        }

        public static IEnumerable<DataRow> AsEnumerable(this DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                yield return item;
            }
        }

        public static Dictionary<string, Object> AsDictionary(this DataRow dr)
        {
            var dict = new Dictionary<string, Object>();
            foreach (DataColumn item in dr.Table.Columns)
            {
                dict.Add(item.ColumnName, dr[item.ColumnName]);
            }

            return dict;
        }
    }

}
