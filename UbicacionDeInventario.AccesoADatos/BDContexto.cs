using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ********************************
using Microsoft.EntityFrameworkCore;
using UbicacionDeInventario.EntidadesDeNegocio;

namespace UbicacionDeInventario.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Bodega> Bodega { get; set; }

        public DbSet<Sucursal> Sucursal { get; set; }

        public DbSet<Estante> Estante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-EMGKJOF;Initial Catalog=Inventaro;Integrated Security=True");
            // optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-90E0RC6\SQLEXPRESS02;Initial Catalog=Inventario;Integrated Security=True");
            // cristian DESKTOP-EMGKJOF
            // natalia  
            optionsBuilder.UseSqlServer(@"Data Source= USUARIO;Initial Catalog=UbicacionDeInventario; Integrated Security = True");
        }
    }
}
