using UbicacionDeInventario.MinimalApi.MVC;
using UbicacionDeInventario.LogicaDeNegocio;
using UbicacionDeInventario.EntidadesDeNegocio;

namespace UbicacionDeInventario.MinimalApi.endPoint
{
    public static class SucursalEnPoint
    {
        public static void addSucursalEndPoits(this WebApplication app)
        {
            // app.MapPost("/Sucursal/create", sucursalBL.CrearAsync);
            app.MapPost("/sucursal/create", async (SucursalCrear pSucursal, SucursalBL sucursal2BL) => {
                return await sucursal2BL.CrearAsync(new Sucursal
                {
                    Nombre = pSucursal.Nombre,
                    Telefono = pSucursal.Telefono,
                    Comentario = pSucursal.Comentario,
                    Direccion = pSucursal.Direccion,
                });
            });
            SucursalBL sucursalBL = new SucursalBL();
            app.MapPost("/rol/delete", sucursalBL.EliminarAsync);
            app.MapPut("/rol", sucursalBL.ModificarAsync);
            app.MapGet("/rol", sucursalBL.ObtenerTodosAsync);
            app.MapPost("/rol/search", sucursalBL.BuscarAsync);
        }
    }
}