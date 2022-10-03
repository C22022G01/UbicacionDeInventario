//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using UbicacionDeInventario.AccesoADatos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

///**********************************/
//using UbicacionDeInventario.EntidadesDeNegocio;

//namespace UbicacionDeInventario.AccesoADatos.Tests
//{
//    [TestClass()]
//    public class BodegaDALTests
//    {
//        private static Bodega bodegaInicial = new Bodega { Id = 2 };  // Agregar un id existente en la base de datos     
//        [TestMethod()]
//        public async Task T1CrearAsyncTest()
//        {
//            var bodega = new Bodega();
//            bodega.IdSucursal = bodegaInicial.IdSucursal;
//            bodega.Nombre = "Admin";
//            bodega.Estatus = (byte)Estatus_Bodega.INACTIVO;
//            bodega.Descripcion = "Test Descripcion";
//            int result = await BodegaDAL.CrearAsync(bodega);
//            Assert.AreNotEqual(0, result);
//            bodegaInicial.Id = bodega.Id;
//        }

//        [TestMethod()]
//        public async Task T2ModificarAsyncTest()
//        {
//            var bodega = new Bodega();
//            bodega.Id = bodegaInicial.Id;
//            bodega.IdSucursal = bodegaInicial.IdSucursal;
//            bodega.Nombre = "Admin";
//            bodega.Estatus = (byte)Estatus_Bodega.INACTIVO;
//            bodega.Descripcion = "Test Descripcion";
//            int result = await BodegaDAL.ModificarAsync(bodega);
//            Assert.AreNotEqual(0, result);

//        }

//        [TestMethod()]
//        public async Task T3ObtenerPorIdAsyncTest()
//        {
//            var bodega = new Bodega();
//            bodega.Id = bodegaInicial.Id;
//            var resultBodega = await BodegaDAL.ObtenerPorIdAsync(bodega);
//            Assert.AreEqual(bodega.Id, resultBodega.Id);
//        }

//        [TestMethod()]
//        public async Task T4ObtenerTodosAsyncTest()
//        {
//            var resultBodegas = await BodegaDAL.ObtenerTodosAsync();
//            Assert.AreNotEqual(0, resultBodegas.Count);
//        }

//        [TestMethod()]
//        public async Task T5BuscarAsyncTest()
//        {
//            var bodega = new Bodega();
//            bodega.IdSucursal = bodegaInicial.IdSucursal;
//            bodega.Nombre = "A";
//            bodega.Estatus = (byte)Estatus_Bodega.INACTIVO;
//            bodega.Descripcion = "D";
//            bodega.Top_Aux = 10;
//            var resultBodegas = await BodegaDAL.BuscarAsync(bodega);
//            Assert.AreNotEqual(0, resultBodegas.Count);
//        }
//        [TestMethod()]
//        public async Task T6BuscarIncluirSucursalesesAsync()
//        {
//            var bodega = new Bodega();
//            bodega.IdSucursal = bodegaInicial.IdSucursal;
//            bodega.Nombre = "Admin";
//            bodega.Estatus = (byte)Estatus_Bodega.INACTIVO;
//            bodega.Descripcion = "Test Descripcion";
//            bodega.Top_Aux = 10;
//            var resultBodegas = await BodegaDAL.BuscarIncluirSucursalesesAsync(bodega);
//            Assert.AreNotEqual(0, resultBodegas.Count);
//            var ultimoBodega = resultBodegas.FirstOrDefault();
//            Assert.IsTrue(ultimoBodega.Sucursal!= null && bodega.IdSucursal == ultimoBodega.Sucursal.Id);



//            [TestMethod()]
//            public async Task T7EliminarAsyncTest()
//          {
//            var bodega = new Bodega();
//            bodega.Id = bodegaInicial.Id;
//            int result = await BodegaDAL.EliminarAsync(bodega);
//            Assert.AreNotEqual(0, result);
//         }
//    }
//}