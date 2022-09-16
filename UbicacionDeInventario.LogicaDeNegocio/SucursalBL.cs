using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//***************************
using UbicacionDeInventario.EntidadesDeNegocio;
using UbicacionDeInventario.AccesoADatos;

namespace UbicacionDeInventario.LogicaDeNegocio
{
    public class SucursalBL
    {
        public async Task<int> CrearAsync(Sucursal pSucursal)
        {
            return await SucursalDAL.CrearAsync(pSucursal);
        }
        public async Task<int> ModificarAsync(Sucursal pSucursal)
        {
            return await SucursalDAL.ModificarAsync(pSucursal);
        }
        public async Task<int> EliminarAsync(Sucursal pSucursal)
        {
            return await SucursalDAL.EliminarAsync(pSucursal);
        }
        public async Task<Sucursal> ObtenerPorIdAsync(Sucursal pSucursal)
        {
            return await SucursalDAL.ObtenerPorIdAsync(pSucursal);
        }
        public async Task<List<Sucursal>> ObtenerTodosAsync()
        {
            return await SucursalDAL.ObtenerTodosAsync();
        }
        public async Task<List<Sucursal>> BuscarAsync(Sucursal pSucursal)
        {
            return await SucursalDAL.BuscarAsync(pSucursal);
        }
    }
}
