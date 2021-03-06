﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIOracle.Controllers
{
    [Produces("application/json")]
    [Route("api/producto")]
    public class ProductoController : Controller
    {
        [HttpGet]
        public Object Get()
        {
            try
            {
                using (var db = new Models.MyFacturaContext())
                {
                    var data = db.Productos.ToList();
                    var total = data.Count();
                    return new { data, total };
                }
            }
            catch (Exception e)
            {
                return new { error = e.ToString() };
            }
        }

        [HttpPost]
        public object Post([FromBody]Models.Producto data)
        {
            try
            {
                using (var db = new Models.MyFacturaContext())
                {
                    //data.Fecha = DateTime.UtcNow;
                    //data.IDFactura = null;
                    db.Productos.Add(data);
                    var total = db.SaveChanges();
                    return new { data, total };
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
                    var data = db.Productos.Where(item => item.IDProducto == id);
                    var total = 0;
                    if (data.Count() > 0)
                    {
                        db.Productos.RemoveRange(data);
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
