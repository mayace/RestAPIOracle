using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIOracle.Models
{
    [Table("FACTURA")]
    public class Factura
    {
        [Key]
        [Column("IDFACTURA")]
        public int? IDFactura { get; set; }
        [Column("IDCLIENTE")]
        public int IDCliente { get; set; }
        [Column("TOTAL")]
        public int Total { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
    }

    [Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        [Column("IDPRODUCTO")]
        public int IDProducto { get; set; }
        //public DateTime FechaRegistro { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("PRECIO")]
        public decimal Precio { get; set; }
    }

    [Table("CLIENTE")]
    public class Cliente {
        [Key]
        [Column("IDCLIENTE")]
        public int IDCliente { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("NIT")]
        public int NIT { get; set; }
    }

    [Table("DETALLE")]
    public class Detalle
    {
        [Key]
        [Column("FACTURA")]
        int IDFactura { get; set; }
        [Key]
        [Column("PRODUCTO")]
        public int IDProducto { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
        [Column("IVA")]
        public decimal IVA { get; set; }
        [Column("SUBTOTAL")]
        public decimal Subtotal { get; set; }
    }

    public class MyFacturaContext : DbContext
    {

        public MyFacturaContext() : base()
        {
            //    var creator = Database.GetService<IDatabaseCreator>();
            //    Database.Migrate();
        }

        public MyFacturaContext(DbContextOptions<MyFacturaContext> options)
       : base(options)
        {
        }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Detalle> Detalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connStr = "Data Source=45.32.22.223:49161/xe;User Id=practicas1;Password=practicas114;";
            //https://stackoverflow.com/a/56343155
            optionsBuilder
                .UseOracle(@"Data Source=159.65.170.43:49161/xe;User Id=practicas1;Password=practicas114;", options => options.UseOracleSQLCompatibility("11"));
                
        }
    }
}
