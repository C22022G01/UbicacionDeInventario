using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// Agregar la siguiente libreria para la seguridad JWT
using UbicacionDeInventario.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using UbicacionDeInventario.EntidadesDeNegocio;
using UbicacionDeInventario.LogicaDeNegocio;
using System.Text.Json;

namespace UbicacionDeInventario.WedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaController : ControllerBase
    {
        private BodegaBL bodegaBL = new BodegaBL();

        // GET: api/<RolController>
        [HttpGet]
        public async Task<IEnumerable<Bodega>> Get()
        {
            return await bodegaBL.ObtenerTodosAsync();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<Bodega> Get(int id)
        {
            Bodega bodega = new Bodega();
            bodega.Id = id;
            return await bodegaBL.ObtenerPorIdAsync(bodega);
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Bodega bodega)
        {
            try
            {
                await bodegaBL.CrearAsync(bodega);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Bodega bodega)
        {

            if (bodega.Id == id)
            {
                await bodegaBL.ModificarAsync(bodega);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Bodega bodega = new Bodega();
                bodega.Id = id;
                await bodegaBL.EliminarAsync(bodega);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Bodega>> Buscar([FromBody] object pBodega)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strBodega = JsonSerializer.Serialize(pBodega);
            Bodega bodega = JsonSerializer.Deserialize<Bodega>(strBodega, option);
            return await bodegaBL.BuscarAsync(bodega);

        }
    }
}

