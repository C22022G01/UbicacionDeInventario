using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Agregar la siguiente librerias
using UbicacionDeInventario.EntidadesDeNegocio;
using UbicacionDeInventario.LogicaDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;


namespace UbicacionDeInventario.WedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // agregar el siguiente metadato para autorizar JWT la Web API
    public class SucursalController : ControllerBase
    {
        private SucursalBL sucursalBL = new SucursalBL();

        // GET: api/<SucursalController>
        [HttpGet]
        public async Task<IEnumerable<Sucursal>> Get()
        {
            return await sucursalBL.ObtenerTodosAsync();
        }

        // GET api/<SucursalController>/5
        [HttpGet("{id}")]
        public async Task<Sucursal> Get(int id)
        {
            Sucursal sucursal = new Sucursal();
            sucursal.Id = id;
            return await sucursalBL.ObtenerPorIdAsync(sucursal);
        }

        // POST api/<SucursalController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Sucursal sucursal)
        {
            try
            {
                await sucursalBL.CrearAsync(sucursal);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<SucursalController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Sucursal sucursal)
        {

            if (sucursal.Id == id)
            {
                await sucursalBL.ModificarAsync(sucursal);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/<SucursalController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                sucursal.Id = id;
                await sucursalBL.EliminarAsync(sucursal);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Sucursal>> Buscar([FromBody] object pSucursal)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strSucursal = JsonSerializer.Serialize(pSucursal);
            Sucursal sucursal = JsonSerializer.Deserialize<Sucursal>(strSucursal, option);
            return await sucursalBL.BuscarAsync(sucursal);

        }
    }
}
