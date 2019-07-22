using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace RestAPIOracle.Controllers
{
    [Produces("application/json")]
    [Route("api/Factura")]
    public class FacturaController : Controller
    {
        // GET: api/Factura
        [HttpGet]
        public Object Get()
        {
            try
            {
                var dt = Datos.EjecutarProcedimiento("proc_factura_sel");

                var data = from item in dt.AsEnumerable()
                           select item.AsDictionary();

                return new { data };
            }
            catch (Exception e)
            {
                return new { error = e.ToString() };
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
