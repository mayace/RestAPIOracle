﻿using Microsoft.EntityFrameworkCore;
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
        [Column("FECHAREGISTRO")]
        public DateTime FechaRegistro { get; set; }
    }

    public class MyFacturaContext : DbContext
    {
        public DbSet<Factura> Facturas { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connStr = "Data Source=45.32.22.223:49161/xe;User Id=practicas1;Password=practicas114;";
            //https://stackoverflow.com/a/56343155
            optionsBuilder
                .UseOracle(@"Data Source=45.32.22.223:49161/xe;User Id=practicas1;Password=practicas114;", options => options.UseOracleSQLCompatibility("11"));
                
        }
    }
}