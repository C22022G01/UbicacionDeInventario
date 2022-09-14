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
    public class BodegaBL
    {
        public async Task<int> CrearAsync(Bodega pBodega)
        {
            return await BodegaDAL.CrearAsync(pBodega);
        }
        public async Task<int> ModificarAsync(Bodega pBodega)
        {
            return await BodegaDAL.ModificarAsync(pBodega);
        }
        public async Task<int> EliminarAsync(Bodega pBodega)
        {
            return await BodegaDAL.EliminarAsync(pBodega);
        }
        public async Task<Bodega> ObtenerPorIdAsync(Bodega pBodega)
        {
            return await BodegaDAL.ObtenerPorIdAsync(pBodega);
        }
        public async Task<List<Bodega>> ObtenerTodosAsync()
        {
            return await BodegaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Bodega>> BuscarAsync(Bodega pBodega)
        {
            return await BodegaDAL.BuscarAsync(pBodega);
        }
    }
}
