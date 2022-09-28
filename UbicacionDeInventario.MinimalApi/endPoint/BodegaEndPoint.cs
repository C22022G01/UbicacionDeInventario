using UbicacionDeInventario.MinimalApi.MVC;
using UbicacionDeInventario.LogicaDeNegocio;
using UbicacionDeInventario.EntidadesDeNegocio;

namespace UbicacionDeInventario.MinimalApi.endPoint
{
    public static class BodegaEndPoint
    {
        public static void addBodegaEndPoits(this WebApplication app)
        {
            // app.MapPost("/Bodega/create", rolBL.CrearAsync);
            app.MapPost("/rol/create", async (BodegaCrear pBodega, BodegaBL bodega2BL) => {
                return await bodega2BL.CrearAsync(new Bodega
                {
                    Nombre = pBodega.Nombre,
                });
            });
            BodegaBL bodegaBL = new BodegaBL();
            app.MapPost("/rol/delete", bodegaBL.EliminarAsync);
            app.MapPut("/rol", bodegaBL.ModificarAsync);
            app.MapGet("/rol", bodegaBL.ObtenerTodosAsync);
            app.MapPost("/rol/search", bodegaBL.BuscarAsync);
        }
    }
}
