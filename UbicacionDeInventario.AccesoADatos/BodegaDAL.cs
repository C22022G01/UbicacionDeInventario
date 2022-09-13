using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//////////////////////////////////////////////////////////////
using Microsoft.EntityFrameworkCore;
using UbicacionDeInventario.EntidadesDeNegocio;

namespace UbicacionDeInventario.AccesoADatos
{
    public class BodegaDAL
    {
        public static async Task<int> CrearAsync(Bodega pBodega)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pBodega);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Bodega pBodega)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var bodega = await bdContexto.Bodega.FirstOrDefaultAsync(s => s.Id == pBodega.Id);
                bodega.IdSucursal = pBodega.IdSucursal;
                bodega.Nombre = pBodega.Nombre;
                bodega.FechaRegistro = pBodega.FechaRegistro;
                bodega.Estatus = pBodega.Estatus;
                bodega.Descripcion = pBodega.Descripcion;
                bdContexto.Update(bodega);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        
        public static async Task<int> EliminarAsync(Bodega pBodega)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var bodega = await bdContexto.Bodega.FirstOrDefaultAsync(s => s.Id == pBodega.Id);
                bdContexto.Bodega.Remove(bodega);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Bodega> ObtenerPorIdAsync(Bodega pBodega)
        {
            var bodega = new Bodega();
            using (var bdContexto = new BDContexto())
            {
                bodega = await bdContexto.Bodega.FirstOrDefaultAsync(s => s.Id == pBodega.Id);
            }
            return bodega;
        }
        public static async Task<List<Bodega>> ObtenerTodosAsync()
        {
            var bodegas = new List<Bodega>();
            using (var bdContexto = new BDContexto())
            {
                bodegas = await bdContexto.Bodega.ToListAsync();
            }
            return bodegas;
        }
        internal static IQueryable<Bodega> QuerySelect(IQueryable<Bodega> pQuery, Bodega pBodega)
        {
            if (pBodega.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pBodega.Id);
            if (!string.IsNullOrWhiteSpace(pBodega.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pBodega.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pBodega.Top_Aux > 0)
                pQuery = pQuery.Take(pBodega.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Bodega>> BuscarAsync(Bodega pBodega)
        {
            var bodegas = new List<Bodega>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Bodega.AsQueryable();
                select = QuerySelect(select, pBodega);
                bodegas = await select.ToListAsync();
            }
            return bodegas;
        }
    }
}
