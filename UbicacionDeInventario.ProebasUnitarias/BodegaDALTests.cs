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
    public class BodegaDALTests
    {
        private static Bodega bodegaInicial = new Bodega { Id = 2 };  // Agregar un id existente en la base de datos     
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var bodega = new Bodega();
            bodega.IdSucursal = bodegaInicial.IdSucursal;
            bodega.Nombre = "Administrador";
            bodegaInicial.Estatus = (byte)Estatus_Bodega.INACTIVO;
            bodega.Descripcion = "Test Descripcion;
            int result = await BodegaDAL.CrearAsync(bodega);
            Assert.AreNotEqual(0, result);
            bodegaInicial.Id = bodega.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var bodega = new Bodega();
            bodega.Id = bodegaInicial.Id;
            bodega.IdSucursal = bodegaInicial.IdSucursal;
            bodega.Nombre = "Admin";
            bodegaInicial.Estatus = (byte)Estatus_Bodega.INACTIVO;
            bodega.Descripcion = "Test Descripcion;
            int result = await BodegaDAL.ModificarAsync(bodega);
            Assert.AreNotEqual(0, result);

        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            var resultRol = await RolDAL.ObtenerPorIdAsync(rol);
            Assert.AreEqual(rol.Id, resultRol.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultRoles = await RolDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultRoles.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "a";
            rol.Top_Aux = 10;
            var resultRoles = await RolDAL.BuscarAsync(rol);
            Assert.AreNotEqual(0, resultRoles.Count);
        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            int result = await RolDAL.EliminarAsync(rol);
            Assert.AreNotEqual(0, result);
        }
    }
}