//using UbicacionDeInventario.MinimalApi.MVC;
//using UbicacionDeInventario.LogicaDeNegocio;
//using UbicacionDeInventario.EntidadesDeNegocio;

//namespace UbicacionDeInventario.MinimalApi.endPoint
//{
//    public static class BodegaEndPoint
//    {
//        public static void addBodegaEndPoits(this WebApplication app)
//        {
//            // app.MapPost("/Bodega/create", bodegaBL.CrearAsync);
//            app.MapPost("/rol/create", async (BodegaCrear pBodega, BodegaBL bodega2BL) => {
//                return await bodega2BL.CrearAsync(new Bodega
//                {
//                    Nombre = pBodega.Nombre,
//                });
//            });
//            BodegaBL bodegaBL = new BodegaBL();
//            app.MapPost("/bodega/delete", bodegaBL.EliminarAsync);
//            app.MapPut("/bodega", bodegaBL.ModificarAsync);
//            app.MapGet("/bodega", bodegaBL.ObtenerTodosAsync);
//            app.MapPost("/bodega/search", bodegaBL.BuscarAsync);
//        }
//    }
//}
