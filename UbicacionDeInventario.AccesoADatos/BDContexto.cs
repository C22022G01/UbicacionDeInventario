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

        public DbSet<Estante> Estante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-EMGKJOF;Initial Catalog=UbicacionDeInventario;Integrated Security=True");
        }
    }
}
