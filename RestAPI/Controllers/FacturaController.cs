using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Factura")]
    public class FacturaController : Controller
    {
        // GET: api/Factura
        [HttpGet]
        public String Get()
        {
            try
            {
                string con = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 45.32.22.223)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = database)));User Id=practicasuser;Password=practicasuser14;";

                string oradb = "Data Source=45.32.22.223;User Id=practicasuser;Password=practicasuser14;";
                OracleConnection conn = new OracleConnection(con);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(1) from factura;";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                conn.Dispose();

                return "ok";
            }
            catch ( Exception e)
            {
                return e.ToString();
            }
        }

        // GET: api/Factura/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Factura
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Factura/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
