using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// Agregar la siguiente libreria para la seguridad JWT
using UbicacionDeInventario.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using UbicacionDeInventario.EntidadesDeNegocio;
using UbicacionDeInventario.LogicaDeNegocio;
using System.Text.Json;

namespace UbicacionDeInventario.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize] // agregar el siguiente metadato para autorizar JWT la Web API
    public class EstanteController : ControllerBase
    {
        private EstanteBL estanteBL = new EstanteBL();

        // GET: api/<RolController>
        [HttpGet]
        public async Task<IEnumerable<Estante>> Get()
        {
            return await estanteBL.ObtenerTodosAsync();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<Estante> Get(int id)
        {
            Estante estante = new Estante();
            estante.Id = id;
            return await estanteBL.ObtenerPorIdAsync(estante);
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Estante estante)
        {
            try
            {
                await estanteBL.CrearAsync(estante);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Estante estante)
        {

            if (estante.Id == id)
            {
                await estanteBL.ModificarAsync(estante);
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
                Estante estante = new Estante();
                estante.Id = id;
                await estanteBL.EliminarAsync(estante);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Estante>> Buscar([FromBody] object pEstante)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEstante = JsonSerializer.Serialize(pEstante);
            Estante estante = JsonSerializer.Deserialize<Estante>(strEstante, option);
            return await estanteBL.BuscarAsync(estante);

        }
    }
}