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
    public class SucursalDAL
    {
        public static async Task<int> CrearAsync(Sucursal pSucursal)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pSucursal);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Sucursal pSucursal)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var sucursal = await bdContexto.Sucursal.FirstOrDefaultAsync(s => s.Id == pSucursal.Id);
                sucursal.Nombre = pSucursal.Nombre;
                sucursal.Telefono = pSucursal.Telefono;
                sucursal.Direccion = pSucursal.Direccion;
                sucursal.Comentario = pSucursal.Comentario;
                bdContexto.Update(sucursal);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Sucursal pSucursal)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var sucursal = await bdContexto.Sucursal.FirstOrDefaultAsync(s => s.Id == pSucursal.Id);
                bdContexto.Sucursal.Remove(sucursal);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Sucursal> ObtenerPorIdAsync(Sucursal pSucursal)
        {
            var sucursal = new Sucursal();
            using (var bdContexto = new BDContexto())
            {
                sucursal = await bdContexto.Sucursal.FirstOrDefaultAsync(s => s.Id == pSucursal.Id);
            }
            return sucursal;
        }
        public static async Task<List<Sucursal>> ObtenerTodosAsync()
        {
            var sucursales = new List<Sucursal>();
            using (var bdContexto = new BDContexto())
            {
                sucursales = await bdContexto.Sucursal.ToListAsync();
            }
            return sucursales;
        }
        internal static IQueryable<Sucursal> QuerySelect(IQueryable<Sucursal> pQuery, Sucursal pSucursal)
        {
            if (pSucursal.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pSucursal.Id);
            if (!string.IsNullOrWhiteSpace(pSucursal.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pSucursal.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pSucursal.Top_Aux > 0)
                pQuery = pQuery.Take(pSucursal.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Sucursal>> BuscarAsync(Sucursal pSucursal)
        {
            var sucursales = new List<Sucursal>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Sucursal.AsQueryable();
                select = QuerySelect(select, pSucursal);
                sucursales = await select.ToListAsync();
            }
            return sucursales;
        }
    }
}
