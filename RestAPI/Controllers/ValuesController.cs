using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            try
            {
                string con = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 45.32.22.223)(PORT = 49161)))(CONNECT_DATA =(SERVICE_NAME = xe)));User Id=system;Password=oracle;";

                //string oradb = "Data Source=45.32.22.223:49161/practicas1;User Id=practicasuser;Password=practicasuser14;";
                string oradb = "Data Source=45.32.22.223:49161/xe;User Id=practicas1;Password=practicas114;";

                using (var conn = new OracleConnection(oradb))
                {

                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select count(1) from factura";
                    cmd.CommandType = CommandType.Text;
                    //OracleDataReader dr = cmd.ExecuteReader();
                    //dr.Read();

                    using (var da = new OracleDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);

                        return dt.Rows.Count.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
