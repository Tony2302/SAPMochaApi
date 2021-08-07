using Microsoft.EntityFrameworkCore;
using SapMochaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPMochaApi.Models
{
    public class sapContext : DbContext
    {

        public sapContext(DbContextOptions<sapContext> options) : base(options)
        {
        }


        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Productores> Productores { get; set; }
        public virtual DbSet<TipoProductores> TipoProductores { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<DetalleCategorias> DetalleCategorias { get; set; }

    }
}
