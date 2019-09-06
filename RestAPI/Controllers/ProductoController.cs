using Microsoft.AspNetCore.Mvc;
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

    }
}
