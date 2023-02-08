using Clientes_API.Entities;
using Clientes_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clientes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clientes = _clientesService.GetClientesList();

                if (clientes == null)
                    return NotFound();
                
                return Ok(clientes);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = _clientesService.GetClienteDetailsById(id);

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                var model = _clientesService.SaveCliente(cliente);
                
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _clientesService.DeleteCliente(id);
            return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

    }
}
