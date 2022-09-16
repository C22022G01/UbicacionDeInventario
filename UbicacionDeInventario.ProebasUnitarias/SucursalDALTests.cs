using Microsoft.VisualStudio.TestTools.UnitTesting;
using UbicacionDeInventario.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbicacionDeInventario.EntidadesDeNegocio;

namespace UbicacionDeInventario.AccesoADatos.Tests
{
    [TestClass()]
    public class SucursalDALTests
    {
        private static Sucursal sucursalInicial = new Sucursal { Id = 2 };  // Agregar un id existente en la base de datos     
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var sucursal = new Sucursal();
            sucursal.Id = sucursalInicial.Id;
            sucursal.Nombre = "Administrador";
            sucursal.Telefono = "";
            sucursal.Comentario = "Tst Comentario";
            sucursal.Direccion = "Test Direccion";
            int result = await SucursalDAL.CrearAsync(sucursal);
            Assert.AreNotEqual(0, result);
            sucursalInicial.Id = sucursal.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var sucursal = new Sucursal();
            sucursal.Id = sucursalInicial.Id;
            sucursal.Nombre = "Administrador";
            sucursal.Telefono = "";
            sucursal.Comentario = "Test Comentario";
            sucursal.Direccion = "Test Direccion";
            int result = await SucursalDAL.ModificarAsync(sucursal);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var sucursal = new Sucursal();
            sucursal.Id = sucursalInicial.Id;
            var resultSucursal = await SucursalDAL.ObtenerPorIdAsync(sucursal);
            Assert.AreEqual(sucursal.Id, resultSucursal.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultSucursales = await SucursalDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultSucursales.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var sucursal = new Sucursal();
            sucursal.Nombre = "a";
            sucursal.Telefono = "0";
            sucursal.Comentario = "Test Comentario";
            sucursal.Direccion = "Test Direccion";
            sucursal.Top_Aux = 10;
            var resultSucurasales = await SucursalDAL.BuscarAsync(sucursal);
            Assert.AreNotEqual(0, resultSucurasales.Count);
        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var sucursal = new Sucursal();
            sucursal.Id = sucursalInicial.Id;
            int result = await SucursalDAL.EliminarAsync(sucursal);
            Assert.AreNotEqual(0, result);
        }
    }
}