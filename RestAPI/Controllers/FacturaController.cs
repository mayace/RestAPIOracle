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
                using (var db = new Models.MyFacturaContext())
                {
                    var data = db.Facturas.ToList();
                    return new { data };
                }
            }
            catch (Exception e)
            {
                return new { error = e.ToString() };
            }
        }

        // GET: api/Factura/5
        [HttpGet("{id}", Name = "Get")]
        public Object Get(int id)
        {
            try
            {
                using (var db = new Models.MyFacturaContext())
                {
                    var data = db.Facturas.Where(item => item.IDFactura == id).ToList();
                    return new { data };
                }
            }
            catch (Exception e)
            {
                return new { error = e.ToString() };
            }
        }

        // POST: api/Factura
        [HttpPost]
        public object Post([FromBody]Models.Factura data)
        {
            try
            {
                using (var db = new Models.MyFacturaContext())
                {
                    data.FechaRegistro = DateTime.UtcNow;
                    data.IDFactura = null;
                    db.Facturas.Add(data);
                    var total = db.SaveChanges();
                    return new { data, total };
                }
            }
            catch (Exception e)
            {
                return new { error = e.ToString() };
            }
        }

        // PUT: api/Factura/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody]Models.Factura change)
        {
            try
            {
                using (var db = new Models.MyFacturaContext())
                {
                    var data = db.Facturas.Where(item => item.IDFactura == id);
                    var total = 0;
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            item.IDCliente = change.IDCliente;
                            item.Total = change.Total;
                        }
                        total = db.SaveChanges();
                    }

                    return new { data = data.ToList(), total };
                }
            }
            catch (Exception e)
            {
                return new { error = e.ToString() };
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            try
            {
                using (var db = new Models.MyFacturaContext())
                {
                    var data = db.Facturas.Where(item => item.IDFactura == id);
                    var total = 0;
                    if (data.Count() > 0)
                    {
                        db.Facturas.RemoveRange(data);
                        total = db.SaveChanges();
                    }

                    return new { data = data.ToList(), total };
                }
            }
            catch (Exception e)
            {
                return new { error = e.ToString() };
            }
        }
    }
}
