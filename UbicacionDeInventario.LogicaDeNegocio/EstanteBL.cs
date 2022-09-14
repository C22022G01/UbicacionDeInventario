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
    public class EstanteBL
    {
        public async Task<int> CrearAsync(Estante pEstante)
        {
            return await EstanteDAL.CrearAsync(pEstante);
        }
        public async Task<int> ModificarAsync(Estante pEstante)
        {
            return await EstanteDAL.ModificarAsync(pEstante);
        }
        public async Task<int> EliminarAsync(Estante pEstante)
        {
            return await EstanteDAL.EliminarAsync(pEstante);
        }
        public async Task<Estante> ObtenerPorIdAsync(Estante pEstante)
        {
            return await EstanteDAL.ObtenerPorIdAsync(pEstante);
        }
        public async Task<List<Estante>> ObtenerTodosAsync()
        {
            return await EstanteDAL.ObtenerTodosAsync();
        }
        public async Task<List<Estante>> BuscarAsync(Estante pEstante)
        {
            return await EstanteDAL.BuscarAsync(pEstante);
        }
    }
}