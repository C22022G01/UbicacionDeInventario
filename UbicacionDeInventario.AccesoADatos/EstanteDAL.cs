using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using UbicacionDeInventario.EntidadesDeNegocio;

namespace UbicacionDeInventario.AccesoADatos
{
    public class EstanteDAL
    {
        public static async Task<int> CrearAsync(Estante pEstante)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pEstante);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Estante pEstante)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var estante = await bdContexto.Estante.FirstOrDefaultAsync(s => s.Id == pEstante.Id);
                estante.IdBodega = pEstante.IdBodega;
                estante.Nombre = pEstante.Nombre;
                bdContexto.Update(estante);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Estante pEstante)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var estante = await bdContexto.Estante.FirstOrDefaultAsync(s => s.Id == pEstante.Id);
                bdContexto.Estante.Remove(estante);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Estante> ObtenerPorIdAsync(Estante pEstante)
        {
            var estante = new Estante();
            using (var bdContexto = new BDContexto())
            {
                estante = await bdContexto.Estante.FirstOrDefaultAsync(s => s.Id == pEstante.Id);
            }
            return estante;
        }
        public static async Task<List<Estante>> ObtenerTodosAsync()
        {
            var estante = new List<Estante>();
            using (var bdContexto = new BDContexto())
            {
                estante = await bdContexto.Estante.ToListAsync();
            }
            return estante;
        }
        internal static IQueryable<Estante> QuerySelect(IQueryable<Estante> pQuery, Estante pEstante)
        {
            if (pEstante.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEstante.Id);
            if (pEstante.IdBodega > 0)
                pQuery = pQuery.Where(s => s.Id == pEstante.IdBodega);
            if (!string.IsNullOrWhiteSpace(pEstante.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEstante.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pEstante.Top_Aux > 0)
                pQuery = pQuery.Take(pEstante.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Estante>> BuscarAsync(Estante pEstante)
        {
            var estantes = new List<Estante>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Estante.AsQueryable();
                select = QuerySelect(select, pEstante);
                estantes = await select.ToListAsync();
            }
            return estantes;
        }
    }
}
