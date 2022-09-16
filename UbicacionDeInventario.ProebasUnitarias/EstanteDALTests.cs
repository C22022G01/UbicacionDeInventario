using Microsoft.VisualStudio.TestTools.UnitTesting;
using UbicacionDeInventario.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**********************************/
using UbicacionDeInventario.EntidadesDeNegocio;

namespace UbicacionDeInventario.AccesoADatos.Tests
{
    [TestClass()]
    public class EstanteDALTests
    {
        private static Estante estanteInicial = new Estante { Id = 2 };  // Agregar un id existente en la base de datos     
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var estante = new Estante();
            estante.IdBodega = estanteInicial.IdBodega;
            estante.Nombre = "Administrador";
            int result = await EstanteDAL.CrearAsync(estante);
            Assert.AreNotEqual(0, result);
            estanteInicial.Id = estante.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var estante = new Estante();
            estante.Id = estanteInicial.Id;
            estante.IdBodega = estanteInicial.IdBodega;
            estante.Nombre = "Admin";
            int result = await EstanteDAL.ModificarAsync(estante);
            Assert.AreNotEqual(0, result);

        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var estante = new Estante();
            estante.Id = estanteInicial.Id;
            var resultEstante = await EstanteDAL.ObtenerPorIdAsync(estante);
            Assert.AreEqual(estante.Id, resultEstante.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultEstantes = await EstanteDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultEstantes.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var estante = new Estante();
            estante.Nombre = "a";
            estante.Top_Aux = 10;
            var resultEstantes = await EstanteDAL.BuscarAsync(estante);
            Assert.AreNotEqual(0, resultEstantes.Count);
        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var estante = new Estante();
            estante.Id = estanteInicial.Id;
            int result = await EstanteDAL.EliminarAsync(estante);
            Assert.AreNotEqual(0, result);
        }
    }
}